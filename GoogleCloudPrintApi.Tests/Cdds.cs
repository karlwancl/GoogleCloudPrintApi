using System;
using System.Collections.Generic;
using GoogleCloudPrintApi.Models.Printer;

namespace GoogleCloudPrintApi.Tests
{
    public static class Cdds
    {
        public static Lazy<CloudDeviceDescription> Cdd => new Lazy<CloudDeviceDescription>(() => new CloudDeviceDescription
        {
            Version = "1.0",
            Printer = new PrinterDescriptionSection
            {
                SupportedContentType = new List<SupportedContentType>
                {
                    new SupportedContentType{ ContentType = "application/pdf", MinVersion = "1.5"},
                    new SupportedContentType{ ContentType = "image/jpeg"},
                    new SupportedContentType{ ContentType = "text/plain"}
                },
                InputTrayUnit = new List<InputTrayUnit>
                {
                    new InputTrayUnit{ VendorId ="tray", Type = InputTrayUnit.TypeType.INPUT_TRAY}
                },
                Marker = new List<Marker>
                {
                    new Marker{ VendorId = "black", Type = Marker.TypeType.INK, Color = new Marker.ColorType{ Type = Marker.ColorType.TypeType.BLACK}},
                    new Marker{ VendorId= "color", Type = Marker.TypeType.INK, Color = new Marker.ColorType{ Type = Marker.ColorType.TypeType.COLOR}}
                },
                Cover = new List<Cover>
                {
                    new Cover{VendorId = "front", Type = Cover.TypeType.CUSTOM, CustomDisplayName = "front cover"}
                },
                VendorCapability = new List<VendorCapability>(),
                Color = new Color
                {
                    Option = new List<Color.OptionType> {
                        new Color.OptionType {Type = Color.Type.STANDARD_MONOCHROME},
                        new Color.OptionType {Type = Color.Type.STANDARD_COLOR, IsDefault = true},
                        new Color.OptionType{VendorId = "ultra-color", Type = Color.Type.CUSTOM_COLOR, CustomDisplayName = "Best Color"}
                    }
                },
                Copies = new Copies { Default = 1, Max = 100 },
                MediaSize = new MediaSize
                {
                    Option = new List<MediaSize.OptionType>
                    {
                        new MediaSize.OptionType{ Name = MediaSize.Name.ISO_A4, WidthMicrons = 210000, HeightMicrons = 297000, IsDefault = true},
                        new MediaSize.OptionType{Name = MediaSize.Name.NA_LEGAL, WidthMicrons = 215900, HeightMicrons = 355600},
                        new MediaSize.OptionType{Name = MediaSize.Name.NA_LETTER, WidthMicrons = 215900, HeightMicrons = 279400}
                    }
                }
            }
        });
    }
}
