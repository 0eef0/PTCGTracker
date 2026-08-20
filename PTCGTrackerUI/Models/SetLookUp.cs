namespace PTCGTrackerUI.Models;

public class SetLookUp
{
    Dictionary<string, string> setLookup = new Dictionary<string, string>
    {
        // ============================================================
        // BLACK & WHITE
        // ============================================================

        { "BLW", "BW01" },   // Black & White
        { "EPO", "BW02" },   // Emerging Powers
        { "NVI", "BW03" },   // Noble Victories
        { "NXD", "BW04" },   // Next Destinies
        { "DEX", "BW05" },   // Dark Explorers
        { "DRX", "BW06" },   // Dragons Exalted
        { "DRV", "DRV" },    // Dragon Vault
        { "BCR", "BW07" },   // Boundaries Crossed
        { "PLS", "BW08" },   // Plasma Storm
        { "PLF", "BW09" },   // Plasma Freeze
        { "PLB", "BW10" },   // Plasma Blast
        { "LTR", "BW11" },   // Legendary Treasures

        // Black & White Promos
        { "BWP", "BWP" },


        // ============================================================
        // XY
        // ============================================================

        { "KSS", "XY00" },   // Kalos Starter Set
        { "XY",  "XY01" },   // XY
        { "FLF", "XY02" },   // Flashfire
        { "FFI", "XY03" },   // Furious Fists
        { "PHF", "XY04" },   // Phantom Forces
        { "PRC", "XY05" },   // Primal Clash
        { "DCR", "DC01" },   // Double Crisis
        { "ROS", "XY06" },   // Roaring Skies
        { "AOR", "XY07" },   // Ancient Origins
        { "BKT", "XY08" },   // BREAKthrough
        { "BKP", "XY09" },   // BREAKpoint
        { "GEN", "G01" },    // Generations
        { "FCO", "XY10" },   // Fates Collide
        { "STS", "XY11" },   // Steam Siege
        { "EVO", "XY12" },   // Evolutions

        // XY Promos
        { "XYP", "XYP" },


        // ============================================================
        // SUN & MOON
        // ============================================================

        { "SUM", "SM01" },   // Sun & Moon
        { "GRI", "SM02" },   // Guardians Rising
        { "BUS", "SM03" },   // Burning Shadows
        { "SLG", "SM3.5" },  // Shining Legends
        { "CIN", "SM04" },   // Crimson Invasion
        { "UPR", "SM05" },   // Ultra Prism
        { "FLI", "SM06" },   // Forbidden Light
        { "CES", "SM07" },   // Celestial Storm
        { "DRM", "SM7.5" },  // Dragon Majesty
        { "LOT", "SM08" },   // Lost Thunder
        { "TEU", "SM09" },   // Team Up
        { "UNB", "SM10" },   // Unbroken Bonds
        { "DET", "DET" },    // Detective Pikachu
        { "UNM", "SM11" },   // Unified Minds
        { "HIF", "SM11.5" }, // Hidden Fates
        { "CEC", "SM12" },   // Cosmic Eclipse

        // Sun & Moon Promos
        { "SMP", "SMP" },


        // ============================================================
        // SWORD & SHIELD
        // ============================================================

        { "SSH", "SWSH01" }, // Sword & Shield
        { "RCL", "SWSH02" }, // Rebel Clash
        { "DAA", "SWSH03" }, // Darkness Ablaze
        { "CPA", "SWSH3.5" },// Champion's Path
        { "VIV", "SWSH04" }, // Vivid Voltage
        { "SHF", "SWSH4.5" },// Shining Fates
        { "BST", "SWSH05" }, // Battle Styles
        { "CRE", "SWSH06" }, // Chilling Reign
        { "EVS", "SWSH07" }, // Evolving Skies
        { "CEL", "CEL25" },  // Celebrations
        { "FST", "SWSH08" }, // Fusion Strike
        { "BRS", "SWSH09" }, // Brilliant Stars
        { "ASR", "SWSH10" }, // Astral Radiance
        { "PGO", "PGO" },    // Pokémon GO
        { "LOR", "SWSH11" }, // Lost Origin
        { "SIT", "SWSH12" }, // Silver Tempest
        { "CRZ", "SWSH12.5" },// Crown Zenith

        // Celebrations Classic Collection
        { "CEL25C", "CEL25C" },

        // Sword & Shield Promos
        { "SWSHP", "SWSHP" },


        // ============================================================
        // SCARLET & VIOLET
        // ============================================================

        { "SVI", "SV01" },    // Scarlet & Violet
        { "PAL", "SV02" },    // Paldea Evolved
        { "OBF", "SV03" },    // Obsidian Flames
        { "MEW", "SV3PT5" },  // 151
        { "PAR", "SV04" },    // Paradox Rift
        { "PAF", "SV4PT5" },  // Paldean Fates
        { "TEF", "SV05" },    // Temporal Forces
        { "TWM", "SV06" },    // Twilight Masquerade
        { "SFA", "SV6PT5" },  // Shrouded Fable
        { "SCR", "SV07" },    // Stellar Crown
        { "SSP", "SV08" },    // Surging Sparks
        { "PRE", "SV8PT5" },  // Prismatic Evolutions
        { "JTG", "SV09" },    // Journey Together
        { "DRI", "SV10" },    // Destined Rivals
        { "BLK", "ZSV10PT5" },// Black Bolt
        { "WHT", "ZSV10PT5" },// White Flare

        // Scarlet & Violet Promos
        { "SVP", "SVP" },


        // ============================================================
        // MEGA EVOLUTION
        // ============================================================

        { "MEE", "MEE" },      // Mega Evolution
        { "MEG", "ME01" },     // Mega Evolution
        { "PFL", "ME02" },     // Phantasmal Flames
        { "ASC", "ME2PT5" },   // Ascended Heroes
        { "POR", "ME03" },     // Perfect Order
        { "CRI", "ME04" },     // Chaos Rising
        { "PBL", "ME05" },     // Pitch Black
    };


    public string GetSetImageCode(string set)
    {
        return setLookup[set];
    }
}