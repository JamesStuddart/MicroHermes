﻿using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleModelQueries : IVehicleModelQueries
    {
        private readonly IDictionary<int, string> values;

        public VehicleModelQueries()
        {
            values = new Dictionary<int, string>
            {
                {1, "H1"},
                {2, "TL"},
                {3, "TLX"},
                {4, "CL"},
                {5, "ILX"},
                {6, "ILX Hybrid"},
                {7, "Civic"},
                {8, "Viper"},
                {9, "Avenger"},
                {10, "Caliber"},
                {11, "SRT Viper"},
                {12, "200"},
                {13, "Sebring"},
                {14, "Dart"},
                {15, "Wrangler"},
                {16, "Compass"},
                {17, "Patriot"},
                {18, "Cherokee"},
                {19, "Liberty"},
                {20, "Durango"},
                {21, "Grand Cherokee"},
                {22, "1500"},
                {23, "Nitro"},
                {24, "Dakota"},
                {25, "Ram Pickup 1500"},
                {26, "Fusion"},
                {27, "Mustang"},
                {28, "Focus"},
                {29, "C-Max Hybrid"},
                {30, "C-Max Energi"},
                {31, "Taurus"},
                {32, "Transit Wagon"},
                {33, "E-Series Wagon"},
                {34, "Explorer"},
                {35, "Escape"},
                {36, "Escape Hybrid"},
                {37, "Explorer Sport Trac"},
                {38, "Expedition"},
                {39, "F-250 Super Duty"},
                {40, "E-Series Van"},
                {41, "F-150"},
                {42, "Ranger"},
                {43, "F-350 Super Duty"},
                {44, "Park Avenue"},
                {45, "LaCrosse"},
                {46, "Lucerne"},
                {47, "LeSabre"},
                {48, "Verano"},
                {49, "ATS Coupe"},
                {50, "ATS"},
                {51, "CTS"},
                {52, "CTS Coupe"},
                {53, "STS"},
                {54, "CTS Wagon"},
                {55, "CTS-V"},
                {56, "CTS-V Coupe"},
                {57, "CTS-V Wagon"},
                {58, "STS-V"},
                {59, "Eldorado"},
                {60, "DTS"},
                {61, "DeVille"},
                {62, "Seville"},
                {63, "XLR"},
                {64, "XLR-V"},
                {65, "Sierra 2500HD"},
                {66, "Sierra 3500HD"},
                {67, "Acadia"},
                {68, "Yukon"},
                {69, "Yukon Hybrid"},
                {70, "Yukon XL"},
                {71, "Canyon"},
                {72, "Sierra 1500"},
                {73, "Escalade"},
                {74, "SRX"},
                {75, "Escalade ESV"},
                {76, "Escalade Hybrid"},
                {77, "Accord"},
                {78, "Accord Hybrid"},
                {79, "Commander"},
                {80, "MKS"},
                {81, "Maxima"},
                {82, "Sentra"},
                {83, "Altima"},
                {84, "Altima Hybrid"},
                {85, "Titan"},
                {86, "Frontier"},
                {87, "NV Cargo"},
                {88, "Corolla"},
                {89, "Passat"},
                {90, "6"},
                {91, "Shelby GT500"},
                {92, "Charger"},
                {93, "Challenger"},
                {94, "300"},
                {95, "C/V Cargo Van"},
                {96, "C/V Tradesman"},
                {97, "CV Tradesman"},
                {98, "Grand Caravan"},
                {99, "Routan"},
                {100, "Terrain"},
                {101, "Edge"},
                {102, "Flex"},
                {103, "Regal"},
                {104, "Century"},
                {105, "XTS"},
                {106, "CR-V"},
                {107, "ZDX"},
                {108, "MDX"},
                {109, "MKX"},
                {110, "MKT"},
                {111, "Town Car"},
                {112, "Matrix"},
                {113, "RX 450h"},
                {114, "RX 350"},
                {115, "RAV4"},
                {116, "PT Cruiser"},
                {117, "500"},
                {118, "Journey"},
                {119, "3500"},
                {120, "2500"},
                {121, "Ram Pickup 3500"},
                {122, "Ram Pickup 2500"},
                {123, "Fusion Hybrid"},
                {124, "Fusion Energi"},
                {125, "Fiesta"},
                {126, "Rendezvous"},
                {127, "Sierra 1500 Hybrid"},
                {128, "Escalade EXT"},
                {129, "Fit"},
                {130, "MKZ"},
                {131, "MKZ Hybrid"},
                {132, "3"},
                {133, "Versa"},
                {134, "Versa Note"},
                {135, "NV200"},
                {136, "Tacoma"},
                {137, "Golf"},
                {138, "Jetta"},
                {139, "Beetle"},
                {140, "Beetle Convertible"},
                {141, "Golf SportWagen"},
                {142, "Jetta SportWagen"},
                {143, "New Beetle"},
                {144, "Eclipse"},
                {145, "Eclipse Spyder"},
                {146, "Outlander Sport"},
                {147, "Endeavor"},
                {148, "Tribute"},
                {149, "M-Class"},
                {150, "GL-Class"},
                {151, "R-Class"},
                {152, "Camry Hybrid"},
                {153, "Avalon Hybrid"},
                {154, "Camry"},
                {155, "Avalon"},
                {156, "Venza"},
                {157, "Z4"},
                {158, "Z3"},
                {159, "X5"},
                {160, "C-Class"},
                {161, "NV Passenger"},
                {162, "Odyssey"},
                {163, "Pilot"},
                {164, "Ridgeline"},
                {165, "Rainier"},
                {166, "Terraza"},
                {167, "Enclave"},
                {168, "H3T"},
                {169, "H3"},
                {170, "Accord Crosstour"},
                {171, "Crosstour"},
                {172, "Element"},
                {173, "RDX"},
                {174, "MKC"},
                {175, "Navigator"},
                {176, "Armada"},
                {177, "JX"},
                {178, "QX60"},
                {179, "Xterra"},
                {180, "Pathfinder"},
                {181, "Rogue"},
                {182, "Murano"},
                {183, "QX56"},
                {184, "Santa Fe"},
                {185, "Elantra"},
                {186, "Sonata"},
                {187, "Highlander Hybrid"},
                {188, "Highlander"},
                {189, "Sequoia"},
                {190, "Sienna"},
                {191, "Tundra"},
                {192, "M"},
                {193, "Z4 M"},
                {194, "X6"},
                {195, "ActiveHybrid X6"},
                {196, "X3"},
                {197, "X4"},
                {198, "Optima"},
                {199, "Sorento"},
                {200, "Santa Fe Sport"},
                {201, "X5 M"},
                {202, "X6 M"},
                {203, "Lancer"},
                {204, "Lancer Sportback"},
                {205, "Outlander"},
                {206, "TSX"},
                {207, "TSX Sport Wagon"},
                {208, "Integra"},
                {209, "RSX"},
                {210, "RL"},
                {211, "RLX"},
                {212, "NSX"},
                {213, "Insight"},
                {214, "CR-Z"},
                {215, "Mazdaspeed 3"},
                {216, "5"},
                {217, "2"},
                {218, "MX-5 Miata"},
                {219, "CX-7"},
                {220, "CX-5"},
                {221, "CX-9"},
                {222, "EX35"},
                {223, "EX"},
                {224, "Q50"},
                {225, "M56"},
                {226, "370Z"},
                {227, "QX50"},
                {228, "M45"},
                {229, "Q70"},
                {230, "G37 Sedan"},
                {231, "G Sedan"},
                {232, "Q40"},
                {233, "G37 Coupe"},
                {234, "G Coupe"},
                {235, "Q60 Coupe"},
                {236, "G37 Convertible"},
                {237, "G Convertible"},
                {238, "Q60 Convertible"},
                {239, "M35"},
                {240, "Quest"},
                {241, "Juke"},
                {242, "FX35"},
                {243, "FX"},
                {244, "Rogue Select"},
                {245, "Murano CrossCabriolet"},
                {246, "Cube"},
                {247, "QX"},
                {248, "QX80"},
                {249, "QX70"},
                {250, "Yaris"},
                {251, "Prius c"},
                {252, "Prius Plug-in"},
                {253, "Prius"},
                {254, "Prius v"},
                {255, "FJ Cruiser"},
                {256, "4Runner"},
                {257, "HS 250h"},
                {258, "GS 450h"},
                {259, "GS 350"},
                {260, "IS 350"},
                {261, "IS 250"},
                {262, "ES 350"},
                {263, "LS 460"},
                {264, "IS F"},
                {265, "ES 300h"},
                {266, "LS 600h L"},
                {267, "IS 350 C"},
                {268, "IS 250 C"},
                {269, "SC 430"},
                {270, "RC 350"},
                {271, "RC F"},
                {272, "CT 200h"},
                {273, "NX 200t"},
                {274, "NX 300h"},
                {275, "GX 460"},
                {276, "LX 570"},
                {277, "Land Cruiser"},
                {278, "Encore"},
                {279, "Tucson"},
                {280, "Veracruz"},
                {281, "Accent"},
                {282, "Elantra GT"},
                {283, "Elantra Touring"},
                {284, "Sonata Hybrid"},
                {285, "Azera"},
                {286, "Genesis"},
                {287, "Equus"},
                {288, "Genesis Coupe"},
                {289, "Veloster"},
                {290, "Rio"},
                {291, "Forte"},
                {292, "Optima Hybrid"},
                {293, "Cadenza"},
                {294, "K900"},
                {295, "Soul"},
                {296, "Sportage"},
                {297, "Sedona"},
                {298, "Mirage"},
                {299, "Transit Connect"},
                {300, "XF"},
                {301, "XJ"},
                {302, "XK"},
                {303, "F-TYPE"},
                {304, "LR4"},
                {305, "Discovery Sport"},
                {306, "LR2"},
                {307, "Range Rover"},
                {308, "Range Rover Sport"},
                {309, "Range Rover Evoque"},
                {310, "Mulsanne"},
                {311, "Continental Flying Spur Speed"},
                {312, "Continental Flying Spur"},
                {313, "Brooklands"},
                {314, "Continental GT Speed"},
                {315, "Continental GT"},
                {316, "Continental Supersports"},
                {317, "Supersports Convertible ISR"},
                {318, "Azure"},
                {319, "Azure T"},
                {320, "Continental GTC Speed"},
                {321, "Continental GTC"},
                {322, "Continental Supersports Convertible"},
                {323, "Flying Spur"},
                {324, "Continental GT Speed Convertible"},
                {325, "Arnage"},
                {326, "Continental"},
                {327, "DB9"},
                {328, "DBS"},
                {329, "DB7"},
                {330, "V8 Vantage"},
                {331, "V12 Vantage"},
                {332, "Virage"},
                {333, "Rapide"},
                {334, "Rapide S"},
                {335, "Vanquish"},
                {336, "TT RS"},
                {337, "TT"},
                {338, "Catera"},
                {339, "allroad"},
                {340, "Q7"},
                {341, "Q5"},
                {342, "SQ5"},
                {343, "Q3"},
                {344, "allroad quattro"},
                {345, "A7"},
                {346, "A8"},
                {347, "A5"},
                {348, "S5"},
                {349, "A4"},
                {350, "A6"},
                {351, "S6"},
                {352, "S8"},
                {353, "S4"},
                {354, "A3"},
                {355, "2 Series"},
                {356, "3 Series"},
                {357, "4 Series"},
                {358, "3 Series Gran Turismo"},
                {359, "4 Series Gran Coupe"},
                {360, "5 Series"},
                {361, "5 Series Gran Turismo"},
                {362, "6 Series Gran Coupe"},
                {363, "6 Series Gran Coupe Sedan"},
                {364, "ALPINA B6 Gran Coupe Sedan"},
                {365, "6 Series"},
                {366, "Z8"},
                {367, "ActiveHybrid 5"},
                {368, "7 Series"},
                {369, "ActiveHybrid 7"},
                {370, "1 Series"},
                {371, "X1"},
                {372, "7 Series Sedan"},
                {373, "ALPINA B7 Sedan"},
                {374, "M3"},
                {375, "M4"},
                {376, "M5"},
                {377, "i8"},
                {378, "Sprinter"},
                {379, "SL-Class"},
                {380, "SLK-Class"},
                {381, "GLK-Class"},
                {382, "G-Class"},
                {383, "CLS-Class"},
                {384, "CL-Class"},
                {385, "E-Class"},
                {386, "S-Class"},
                {387, "Cayman"},
                {388, "911"},
                {389, "Panamera"},
                {390, "Boxster"},
                {391, "Cayenne"},
                {392, "R8"},
                {393, "RS 4"},
                {394, "RS 6"},
                {395, "RS 7"},
                {396, "Touareg"},
                {397, "Tiguan"},
                {398, "Eos"},
                {399, "CC"},
                {400, "GTI"},
                {401, "V60"},
                {402, "S60"},
                {403, "S40"},
                {404, "V50"},
                {405, "S80"},
                {406, "C70"},
                {407, "C30"},
                {408, "V70"},
                {409, "XC60"},
                {410, "XC70"},
                {411, "V60 Cross Country"},
                {412, "XC90"},
                {413, "500L"},
                {414, "599"},
                {415, "458 Italia"},
                {416, "Gallardo"},
            };
        }

        public int GetId(string value)
        {
            return values.First(x => x.Value.Equals(value)).Key;
        }
        
        public string GetValue(int id)
        {
            return values.First(x => x.Key.Equals(id)).Value;
        }
    }
}