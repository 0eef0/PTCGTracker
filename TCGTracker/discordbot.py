import discord
from discord.ext import commands
import logging
from dotenv import load_dotenv
import os
from ImportScript import *
from db import get_db_connection
import random

load_dotenv()
token = os.getenv('DISCORD_TOKEN')

handler = logging.FileHandler(filename='discord.log', encoding='utf-8', mode='w')
intents = discord.Intents.default()
intents.message_content = True
intents.members = True

bot = commands.Bot(command_prefix='/', intents=intents)

@bot.event
async def on_ready():
    print(f"We are ready to go in, {bot.user.name}")
    synced = await bot.tree.sync()
    print(f"Synced {len(synced)} commands:")

    for command in synced:
        print(
            f"Command: /{command.name} | "
            f"Description: {command.description}"
        )

@bot.tree.command(name='poem', description='Sends a beautiful poem')
async def poem(interaction: discord.Interaction):
    await interaction.response.send_message('''Monkeys can climb
Crickets can leap
Horses can race
Owls can seek
Cheetahs can run
Eagles can fly
People can try
But that's about it.''')

@bot.tree.command(name='link', description='Link to tracker UI')
async def poem(interaction: discord.Interaction):
    await interaction.response.send_message('Link goes here')

class DecklistModal(discord.ui.Modal, title="Upload Decklist"):

    deckname = discord.ui.TextInput(
        label="Deck Name",
        placeholder="Name your deck...",
        style = discord.TextStyle.paragraph,
        required=True,
    )

    decklist = discord.ui.TextInput(
        label="Decklist",
        placeholder="Paste your decklist here...",
        style = discord.TextStyle.paragraph,
        required=True,
        max_length=4000
    )

    async def on_submit(self, interaction: discord.Interaction):
        await interaction.response.defer()
        decklist_text = self.decklist.value
        deckname_text = self.deckname.value
        username = interaction.user.name
        deckUpload(decklist_text, deckname_text, username)
        await interaction.followup.send(
            f"Your {deckname_text} deck has been submitted to the database!",  ephemeral=True
        )

@bot.tree.command(name="upload", description="Upload a decklist to the database")
async def uploaddecklist(interaction: discord.Interaction):
    await interaction.response.send_modal(DecklistModal())

@bot.tree.command(name="delete", description="Delete a decklist from the database")
async def uploaddecklist(interaction: discord.Interaction, deckname: str, version: str):
    username = interaction.user.name
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""DELETE FROM \"Deck\" USING \"User\" WHERE u_username = %s AND d_name = %s AND d_version = %s""", (username, deckname, version,))
    conn.commit()
    cursor.close()
    conn.close()
    await interaction.response.send_message(f"Your {deckname} deck has been removed from the database!", ephemeral=True)

@bot.tree.command(name="mydecks", description="Get a list of all your decks and their stats")
async def mydecks(interaction: discord.Interaction):
    username = interaction.user.name
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""SELECT * FROM \"Deck\" JOIN \"User\" ON u_userid = d_userid WHERE u_username = %s""", (username,))
    decks = cursor.fetchall()
    cursor.close()
    conn.close()

    deckstring = ""
    for deck in decks:
        deckstring += f"{deck[2]}-v{deck[5]}.0 | {deck[3]}/{deck[4]} W/L\n "

    await interaction.response.send_message(f"{deckstring}",  ephemeral=True)

@bot.tree.command(name="randomdeck", description="Get a random deck from your list to play")
async def randomdeck(interaction: discord.Interaction):
    username = interaction.user.name
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""SELECT * FROM \"Deck\" JOIN \"User\" ON u_userid = d_userid WHERE u_username = %s""", (username,))
    decks = cursor.fetchall()
    cursor.close()
    conn.close()

    randomselect = random.choice(decks)
    await interaction.response.send_message(f"Your randomly selected deck is: {randomselect[2]}!",  ephemeral=True)

@bot.tree.command(name="cardstats", description="See the usage stats of a specific card")
async def cardstats(interaction: discord.Interaction, cardname: str):
    username = interaction.user.name
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""SELECT d_deckid, d_name, d_version, dc_name, dc_set, dc_setnumber, dc_qtylist, dc_qtydeck FROM \"DeckCard\"
                JOIN \"Deck\" on d_deckid = dc_deckid JOIN \"User\" ON u_userid = d_userid WHERE u_username = %s AND dc_name LIKE %s
                """, (username, f"%{cardname}%", ))
    cards = cursor.fetchall()
    cursor.close()
    conn.close()
    cardstatstring = ""

    for card in cards:
        cardstatstring += f"{card[1]}-v{card[2]}.0: {card[3]} ({card[4]} - {card[5]}) | {card[6]} list - {card[7]} physical\n"

    if cardstatstring:
        await interaction.response.send_message(f"{cardstatstring}", ephemeral=True)
    else:
        await interaction.response.send_message(f"Sorry, Requested card was not found", ephemeral=True)

@bot.tree.command(name="register", description="Register User in database")
async def newuser(interaction: discord.Interaction):
    username = interaction.user.name
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""INSERT INTO \"User\" (u_username) VALUES (%s)""", (username,))
    conn.commit()
    cursor.close()
    conn.close()
    await interaction.response.send_message("You have been registered to the database!", ephemeral=True)

@bot.tree.command(name="remove", description="Remove User from database")
async def deleteuser(interaction: discord.Interaction):
    username = interaction.user.name
    conn = get_db_connection()
    cursor = conn.cursor()
    cursor.execute("""DELETE FROM \"User\" WHERE u_username = %s""", (username,))
    conn.commit()
    cursor.close()
    conn.close()
    await interaction.response.send_message("You have been removed from the database!",  ephemeral=True)

bot.run(token, log_handler=handler, log_level=logging.DEBUG)