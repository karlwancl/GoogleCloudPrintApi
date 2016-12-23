using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleCloudPrintApi.Models.Printer
{

    /// <summary>
    /// A localized human-readable string translated to a specific locale.
    /// It is recommended to include translations of custom strings only for locales
    /// for which significant use of the device can be expected. If the translation
    /// of a custom string for a user's language and country (e.g. ZH_TW) is not
    /// present, GCP will display the translation for the base language (e.g. ZH).
    /// If neither translation is present, the translation for EN (which is required
    /// in every list of localized strings) will be displayed.
    /// </summary>
    public class LocalizedString
    {
        public LocalizedString(Locale locale, string value)
        {
            StringLocale = locale;
            Value = value;
        }

        /// <summary>
        /// Locale that the string is translated to (required).
        /// </summary>
        public Locale StringLocale { get; private set; }

        /// <summary>
        /// Translated content of the string (required).
        /// </summary>
        public string Value { get; private set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Locale
        {
            AF = 0,
            AM = 1,
            AR = 2,
            AR_XB = 3,
            BG = 4,
            BN = 5,
            CA = 6,
            CS = 7,
            CY = 8,
            DA = 9,
            DE = 10,
            DE_AT = 11,
            DE_CH = 12,
            EL = 13,
            EN = 14,
            EN_GB = 15,
            EN_IE = 16,
            EN_IN = 17,
            EN_SG = 18,
            EN_XA = 19,
            EN_XC = 20,
            EN_ZA = 21,
            ES = 22,
            ES_419 = 23,
            ES_AR = 24,
            ES_BO = 25,
            ES_CL = 26,
            ES_CO = 27,
            ES_CR = 28,
            ES_DO = 29,
            ES_EC = 30,
            ES_GT = 31,
            ES_HN = 32,
            ES_MX = 33,
            ES_NI = 34,
            ES_PA = 35,
            ES_PE = 36,
            ES_PR = 37,
            ES_PY = 38,
            ES_SV = 39,
            ES_US = 40,
            ES_UY = 41,
            ES_VE = 42,
            ET = 43,
            EU = 44,
            FA = 45,
            FI = 46,
            FR = 47,
            FR_CA = 48,
            FR_CH = 49,
            GL = 50,
            GU = 51,
            HE = 52,
            HI = 53,
            HR = 54,
            HU = 55,
            HY = 56,
            ID = 57,
            IN = 58,
            IT = 59,
            JA = 60,
            KA = 61,
            KM = 62,
            KN = 63,
            KO = 64,
            LN = 65,
            LO = 66,
            LT = 67,
            LV = 68,
            ML = 69,
            MO = 70,
            MR = 71,
            MS = 72,
            NB = 73,
            NE = 74,
            NL = 75,
            NO = 76,
            PL = 77,
            PT = 78,
            PT_BR = 79,
            PT_PT = 80,
            RM = 81,
            RO = 82,
            RU = 83,
            SK = 84,
            SL = 85,
            SR = 86,
            SR_LATN = 87,
            SV = 88,
            SW = 89,
            TA = 90,
            TE = 91,
            TH = 92,
            TL = 93,
            TR = 94,
            UK = 95,
            UR = 96,
            VI = 97,
            ZH = 98,
            ZH_CN = 99,
            ZH_HK = 100,
            ZH_TW = 101,
            ZU = 102
        }
    }

}
