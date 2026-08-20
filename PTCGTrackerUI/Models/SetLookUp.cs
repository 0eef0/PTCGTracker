namespace PTCGTrackerUI.Models;

public class SetLookUp
{
    private readonly Dictionary<string, string> setLookup = new()
    {
        // ============================================================
        // BLACK & WHITE
        // ============================================================

        { "BLW", "BW01" },
        { "EPO", "BW02" },
        { "NVI", "BW03" },
        { "NXD", "BW04" },
        { "DEX", "BW05" },
        { "DRX", "BW06" },
        { "DRV", "DRV" },
        { "BCR", "BW07" },
        { "PLS", "BW08" },
        { "PLF", "BW09" },
        { "PLB", "BW10" },
        { "LTR", "BW11" },

        { "BWP", "BWP" },


        // ============================================================
        // XY
        // ============================================================

        { "KSS", "XY00" },
        { "XY",  "XY01" },
        { "FLF", "XY02" },
        { "FFI", "XY03" },
        { "PHF", "XY04" },
        { "PRC", "XY05" },
        { "DCR", "DC01" },
        { "ROS", "XY06" },
        { "AOR", "XY07" },
        { "BKT", "XY08" },
        { "BKP", "XY09" },
        { "GEN", "G01" },
        { "FCO", "XY10" },
        { "STS", "XY11" },
        { "EVO", "XY12" },

        { "XYP", "XYP" },


        // ============================================================
        // SUN & MOON
        // ============================================================

        { "SUM", "SM01" },
        { "GRI", "SM02" },
        { "BUS", "SM03" },
        { "SLG", "SM3.5" },
        { "CIN", "SM04" },
        { "UPR", "SM05" },
        { "FLI", "SM06" },
        { "CES", "SM07" },
        { "DRM", "SM7.5" },
        { "LOT", "SM08" },
        { "TEU", "SM09" },
        { "UNB", "SM10" },
        { "DET", "DET" },
        { "UNM", "SM11" },
        { "HIF", "SM11.5" },
        { "CEC", "SM12" },

        { "SMP", "SMP" },


        // ============================================================
        // SWORD & SHIELD
        // ============================================================

        { "SSH", "SWSH01" },
        { "RCL", "SWSH02" },
        { "DAA", "SWSH03" },
        { "CPA", "SWSH3.5" },
        { "VIV", "SWSH04" },
        { "SHF", "SWSH4.5" },
        { "BST", "SWSH05" },
        { "CRE", "SWSH06" },
        { "EVS", "SWSH07" },
        { "CEL", "CEL25" },
        { "FST", "SWSH08" },
        { "BRS", "SWSH09" },
        { "ASR", "SWSH10" },
        { "PGO", "PGO" },
        { "LOR", "SWSH11" },
        { "SIT", "SWSH12" },
        { "CRZ", "SWSH12.5" },

        { "CEL25C", "CEL25C" },
        { "SWSHP", "SWSHP" },


        // ============================================================
        // SCARLET & VIOLET
        // ============================================================

        { "SVI", "SV01" },
        { "PAL", "SV02" },
        { "OBF", "SV03" },
        { "MEW", "SV3PT5" },
        { "PAR", "SV04" },
        { "PAF", "SV4PT5" },
        { "TEF", "SV05" },
        { "TWM", "SV06" },
        { "SFA", "SV6PT5" },
        { "SCR", "SV07" },
        { "SSP", "SV08" },
        { "PRE", "SV8PT5" },
        { "JTG", "SV09" },
        { "DRI", "SV10" },
        { "BLK", "ZSV10PT5" },
        { "WHT", "ZSV10PT5" },

        { "SVP", "SVP" },

        // Scarlet & Violet Basic Energy
        { "SVE", "SVE" },


        // ============================================================
        // MEGA EVOLUTION
        // ============================================================

        // Mega Evolution Basic Energy
        { "MEE", "MEE" },

        { "MEG", "ME01" },
        { "PFL", "ME02" },
        { "ASC", "ME2PT5" },
        { "POR", "ME03" },
        { "CRI", "ME04" },
        { "PBL", "ME05" }
    };


    public string GetSetImageCode(string set)
    {
        if (setLookup.TryGetValue(set, out var imageCode))
            return imageCode;

        throw new KeyNotFoundException(
            $"No image code mapping exists for set '{set}'.");
    }
}
