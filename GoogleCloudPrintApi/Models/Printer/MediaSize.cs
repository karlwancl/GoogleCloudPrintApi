using System.Collections.Generic;

namespace GoogleCloudPrintApi.Models.Printer
{
	/// <summary>
	/// Capability that defines the media sizes available on a device.
	/// </summary>
	public class MediaSize
    {
		/// <summary>
		/// Enumeration of media size names. This is used for UI purposes.
		/// </summary>
		public enum Name
        {
			CUSTOM = 0,

			// North American standard sheet media names.
			NA_INDEX_3X5 = 100,
			NA_PERSONAL = 101,
			NA_MONARCH = 102,
			NA_NUMBER_9 = 103,
			NA_INDEX_4X6 = 104,
			NA_NUMBER_10 = 105,
			NA_A2 = 106,
			NA_NUMBER_11 = 107,
			NA_NUMBER_12 = 108,
			NA_5X7 = 109,
			NA_INDEX_5X8 = 110,
			NA_NUMBER_14 = 111,
			NA_INVOICE = 112,
			NA_INDEX_4X6_EXT = 113,
			NA_6X9 = 114,
			NA_C5 = 115,
			NA_7X9 = 116,
			NA_EXECUTIVE = 117,
			NA_GOVT_LETTER = 118,
			NA_GOVT_LEGAL = 119,
			NA_QUARTO = 120,
			NA_LETTER = 121,
			NA_FANFOLD_EUR = 122,
			NA_LETTER_PLUS = 123,
			NA_FOOLSCAP = 124,
			NA_LEGAL = 125,
			NA_SUPER_A = 126,
			NA_9X11 = 127,
			NA_ARCH_A = 128,
			NA_LETTER_EXTRA = 129,
			NA_LEGAL_EXTRA = 130,
			NA_10X11 = 131,
			NA_10X13 = 132,
			NA_10X14 = 133,
			NA_10X15 = 134,
			NA_11X12 = 135,
			NA_EDP = 136,
			NA_FANFOLD_US = 137,
			NA_11X15 = 138,
			NA_LEDGER = 139,
			NA_EUR_EDP = 140,
			NA_ARCH_B = 141,
			NA_12X19 = 142,
			NA_B_PLUS = 143,
			NA_SUPER_B = 144,
			NA_C = 145,
			NA_ARCH_C = 146,
			NA_D = 147,
			NA_ARCH_D = 148,
			NA_ASME_F = 149,
			NA_WIDE_FORMAT = 150,
			NA_E = 151,
			NA_ARCH_E = 152,
			NA_F = 153,

			// Chinese standard sheet media size names.
			ROC_16K = 200,
			ROC_8K = 201,
			PRC_32K = 202,
			PRC_1 = 203,
			PRC_2 = 204,
			PRC_4 = 205,
			PRC_5 = 206,
			PRC_8 = 207,
			PRC_6 = 208,
			PRC_3 = 209,
			PRC_16K = 210,
			PRC_7 = 211,
			OM_JUURO_KU_KAI = 212,
			OM_PA_KAI = 213,
			OM_DAI_PA_KAI = 214,
			PRC_10 = 215,

			// ISO standard sheet media size names.
			ISO_A10 = 301,
			ISO_A9 = 302,
			ISO_A8 = 303,
			ISO_A7 = 304,
			ISO_A6 = 305,
			ISO_A5 = 306,
			ISO_A5_EXTRA = 307,
			ISO_A4 = 308,
			ISO_A4_TAB = 309,
			ISO_A4_EXTRA = 310,
			ISO_A3 = 311,
			ISO_A4X3 = 312,
			ISO_A4X4 = 313,
			ISO_A4X5 = 314,
			ISO_A4X6 = 315,
			ISO_A4X7 = 316,
			ISO_A4X8 = 317,
			ISO_A4X9 = 318,
			ISO_A3_EXTRA = 319,
			ISO_A2 = 320,
			ISO_A3X3 = 321,
			ISO_A3X4 = 322,
			ISO_A3X5 = 323,
			ISO_A3X6 = 324,
			ISO_A3X7 = 325,
			ISO_A1 = 326,
			ISO_A2X3 = 327,
			ISO_A2X4 = 328,
			ISO_A2X5 = 329,
			ISO_A0 = 330,
			ISO_A1X3 = 331,
			ISO_A1X4 = 332,
			ISO_2A0 = 333,
			ISO_A0X3 = 334,
			ISO_B10 = 335,
			ISO_B9 = 336,
			ISO_B8 = 337,
			ISO_B7 = 338,
			ISO_B6 = 339,
			ISO_B6C4 = 340,
			ISO_B5 = 341,
			ISO_B5_EXTRA = 342,
			ISO_B4 = 343,
			ISO_B3 = 344,
			ISO_B2 = 345,
			ISO_B1 = 346,
			ISO_B0 = 347,
			ISO_C10 = 348,
			ISO_C9 = 349,
			ISO_C8 = 350,
			ISO_C7 = 351,
			ISO_C7C6 = 352,
			ISO_C6 = 353,
			ISO_C6C5 = 354,
			ISO_C5 = 355,
			ISO_C4 = 356,
			ISO_C3 = 357,
			ISO_C2 = 358,
			ISO_C1 = 359,
			ISO_C0 = 360,
			ISO_DL = 361,
			ISO_RA2 = 362,
			ISO_SRA2 = 363,
			ISO_RA1 = 364,
			ISO_SRA1 = 365,
			ISO_RA0 = 366,
			ISO_SRA0 = 367,

			// Japanese standard sheet media size names.
			JIS_B10 = 400,
			JIS_B9 = 401,
			JIS_B8 = 402,
			JIS_B7 = 403,
			JIS_B6 = 404,
			JIS_B5 = 405,
			JIS_B4 = 406,
			JIS_B3 = 407,
			JIS_B2 = 408,
			JIS_B1 = 409,
			JIS_B0 = 410,
			JIS_EXEC = 411,
			JPN_CHOU4 = 412,
			JPN_HAGAKI = 413,
			JPN_YOU4 = 414,
			JPN_CHOU2 = 415,
			JPN_CHOU3 = 416,
			JPN_OUFUKU = 417,
			JPN_KAHU = 418,
			JPN_KAKU2 = 419,

			// Other metric standard sheet media size names.
			OM_SMALL_PHOTO = 500,
			OM_ITALIAN = 501,
			OM_POSTFIX = 502,
			OM_LARGE_PHOTO = 503,
			OM_FOLIO = 504,
			OM_FOLIO_SP = 505,
			OM_INVITE = 506
        }

        public class OptionType
        {
            public Name Name { get; set; }

			/// <summary>
			/// Both of the fields ("width_microns" and "height_microns") are required
			/// if "is_continuous_feed" is set to false. If "is_continuous_feed" is set
			/// to true only one of these fields is required.
			/// </summary>
			/// <value>The width microns.</value>
			public int WidthMicrons { get; set; }

            public int HeightMicrons { get; set; }

            public bool IsContinuousFeed { get; set; }

            public bool IsDefault { get; set; }

			/// <summary>
			/// Non-localized user-friendly string that represents this option.
			/// New CDDs should use custom_display_name_localized instead. It is required
			/// that either custom_display_name or custom_display_name_localized is set
			/// for options whose "name" field is CUSTOM.
			/// </summary>
			/// <value>The name of the custom display.</value>
			public string CustomDisplayName { get; set; }

			/// <summary>
			/// Vendor-provided ID for the media size option. Used to disambiguate media
			/// sizes that may have the same width and height but a different effect on
			/// the printer.
			/// </summary>
			/// <value>The vendor identifier.</value>
			public string VendorId { get; set; }

			/// <summary>
			/// Translations of custom display name of the option.
			/// If not empty, must contain an entry with locale == EN.
			/// </summary>
			/// <value>The custom display name localized.</value>
			public IList<LocalizedString> CustomDisplayNameLocalized { get; set; }
        }

        public IList<OptionType> Option { get; set; }

        public int MinWidthMicrons { get; set; }

        public int MaxWidthMicrons { get; set; }

        public int MinHeightMicrons { get; set; }

        public int MaxHeightMicrons { get; set; }
    }
}