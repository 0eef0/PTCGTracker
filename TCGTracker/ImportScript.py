from db import get_db_connection

def deckUpload(text, deckname, username):
    Categories = text.split("\n\n")

    Regulation = {
        "SVI": "G", "PAL": "G", "OBF": "G", "MEW": "G", "PAR": "G", "PAF": "G",
        "TEF": "H", "TWM": "H", "SFA": "H", "SCR": "H", "SSP": "H", "PRE": "H",
        "JTG": "I", "DRI": "I", "BLK": "I", "WHT": "I", "MEG": "I", "PFL": "I", "ASC": "I",
        "POR": "J", "CRI": "J", "PBL": "J", "30C": "J",
    }

    # Pokemon
    Pokemon = Categories[0]
    Pokemon = Pokemon.split("\n")

    PokemonInDeck = []

    for card in Pokemon:
        if card != Pokemon[0]:
            card = card.split(" ")
            index = 1
            cardName = ""
            while index < len(card) - 2:
                cardName += card[index] + " "
                index += 1

            if card[len(card) - 2] in Regulation.keys():
                regMark = Regulation[card[len(card) - 2]]
            else:
                regMark = "Other"

            PokemonInDeck.append({
                "Name": cardName.strip(),
                "Set": card[len(card) - 2],
                "Number": card[len(card) - 1],
                "QTYinDeck": card[0],
                "Regulation": regMark
            })

    # Trainers
    Trainers = Categories[1]
    Trainers = Trainers.split("\n")

    TrainerInDeck = []

    for card in Trainers:
        if card != Trainers[0]:
            card = card.split(" ")
            index = 1
            cardName = ""
            while index < len(card) - 2:
                cardName += card[index] + " "
                index += 1

            if card[len(card) - 2] in Regulation.keys():
                regMark = Regulation[card[len(card) - 2]]
            else:
                regMark = "Other"

            TrainerInDeck.append({
                "Name": cardName.strip(),
                "Set": card[len(card) - 2],
                "Number": card[len(card) - 1],
                "QTYinDeck": card[0],
                "Regulation": regMark
            })

    # Energy
    Energy = Categories[2]
    Energy = Energy.split("\n")

    EnergyInDeck = []

    for card in Energy:
        if card != Energy[0]:
            card = card.split(" ")
            index = 1
            cardName = ""
            while index < len(card) - 2:
                cardName += card[index] + " "
                index += 1

            if card[len(card) - 2] in Regulation.keys():
                regMark = Regulation[card[len(card) - 2]]
            else:
                regMark = "Other"

            EnergyInDeck.append({
                "Name": cardName.strip(),
                "Set": card[len(card) - 2],
                "Number": card[len(card) - 1],
                "QTYinDeck": card[0],
                "Regulation": regMark
            })

    # Database
    conn = get_db_connection()
    cursor = conn.cursor()

    cursor.execute("""SELECT * FROM \"User\" WHERE u_username = %s""", (username,))
    userid = cursor.fetchone()[0]

    cursor.execute("""SELECT d_version FROM \"Deck\" WHERE d_userid = %s AND d_name = %s""", (userid, deckname))
    version = cursor.fetchone()

    if version == None:
        cursor.execute(
            """INSERT INTO \"Deck\" (d_userid, d_name, d_wins, d_losses, d_version) VALUES (%s, %s, %s, %s, %s) RETURNING d_deckid""",
            (userid, deckname, 0, 0, 1))
        deckid = cursor.fetchone()[0]
        conn.commit()
    else:
        cursor.execute(
            """INSERT INTO \"Deck\" (d_userid, d_name, d_wins, d_losses, d_version) VALUES (%s, %s, %s, %s, %s) RETURNING d_deckid""",
            (userid, deckname, 0, 0, version[0] + 1))
        deckid = cursor.fetchone()[0]
        conn.commit()

    for card in PokemonInDeck:
        cursor.execute("""INSERT INTO \"DeckCard\" (dc_deckid, dc_qtylist, dc_qtydeck, dc_name, dc_set, dc_reg, dc_type, dc_setnumber) 
                           VALUES (%s, %s, %s, %s, %s, %s, %s, %s)""",
                       (deckid, card["QTYinDeck"], 0, card["Name"], card["Set"], card["Regulation"], "Pokemon",
                        card["Number"]))
        conn.commit()

    for card in TrainerInDeck:
        cursor.execute("""INSERT INTO \"DeckCard\" (dc_deckid, dc_qtylist, dc_qtydeck, dc_name, dc_set, dc_reg, dc_type, dc_setnumber) 
                           VALUES (%s, %s, %s, %s, %s, %s, %s, %s)""",
                       (deckid, card["QTYinDeck"], 0, card["Name"], card["Set"], card["Regulation"], "Trainer",
                        card["Number"]))
        conn.commit()

    for card in EnergyInDeck:
        cursor.execute("""INSERT INTO \"DeckCard\" (dc_deckid, dc_qtylist, dc_qtydeck, dc_name, dc_set, dc_reg, dc_type, dc_setnumber) 
                           VALUES (%s, %s, %s, %s, %s, %s, %s, %s)""",
                       (deckid, card["QTYinDeck"], 0, card["Name"], card["Set"], card["Regulation"], "Energy",
                        card["Number"]))
        conn.commit()

    cursor.close()
    conn.close()








