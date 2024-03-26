﻿namespace NierReincarnationRecap.App.Components.UserRecap;

public static class SubjugationExtensions
{
    public static string ToSubjugationToRank(this long score)
    {
        return score switch
        {
            0 => "-",
            < 2000 => "G1",
            < 4000 => "G2",
            < 6000 => "G3",
            < 8000 => "G4",
            < 10000 => "G5",
            < 14000 => "G6",
            < 18000 => "G7",
            < 22000 => "G8",
            < 26000 => "G9",
            < 30000 => "G10",
            < 35000 => "F1",
            < 40000 => "F2",
            < 45000 => "F3",
            < 50000 => "F4",
            < 55000 => "F5",
            < 60000 => "F6",
            < 65000 => "F7",
            < 70000 => "F8",
            < 75000 => "F9",
            < 80000 => "F10",
            < 85000 => "E1",
            < 90000 => "E2",
            < 95000 => "E3",
            < 100000 => "E4",
            < 105000 => "E5",
            < 110000 => "E6",
            < 120000 => "E7",
            < 130000 => "E8",
            < 140000 => "E9",
            < 150000 => "E10",
            < 160000 => "D1",
            < 170000 => "D2",
            < 180000 => "D3",
            < 190000 => "D4",
            < 200000 => "D5",
            < 210000 => "D6",
            < 220000 => "D7",
            < 230000 => "D8",
            < 240000 => "D9",
            < 250000 => "D10",
            < 270000 => "C1",
            < 290000 => "C2",
            < 310000 => "C3",
            < 330000 => "C4",
            < 350000 => "C5",
            < 370000 => "C6",
            < 390000 => "C7",
            < 410000 => "C8",
            < 430000 => "C9",
            < 450000 => "C10",
            < 480000 => "B1",
            < 510000 => "B2",
            < 540000 => "B3",
            < 570000 => "B4",
            < 600000 => "B5",
            < 640000 => "B6",
            < 680000 => "B7",
            < 720000 => "B8",
            < 760000 => "B9",
            < 800000 => "B10",
            < 850000 => "A1",
            < 900000 => "A2",
            < 950000 => "A3",
            < 1000000 => "A4",
            < 1050000 => "A5",
            < 1100000 => "A6",
            < 1200000 => "A7",
            < 1300000 => "A8",
            < 1400000 => "A9",
            < 1500000 => "A10",
            < 1650000 => "S1",
            < 1800000 => "S2",
            < 1950000 => "S3",
            < 2100000 => "S4",
            < 2300000 => "S5",
            < 2500000 => "S6",
            < 2750000 => "S7",
            < 3000000 => "S8",
            < 3250000 => "S9",
            < 3500000 => "S10",
            < 3800000 => "SS1",
            < 4100000 => "SS2",
            < 4400000 => "SS3",
            < 4700000 => "SS4",
            < 5000000 => "SS5",
            < 5300000 => "SS6",
            < 5700000 => "SS7",
            < 6100000 => "SS8",
            < 6500000 => "SS9",
            < 9500000 => "SS10",
            < 15000000 => "SSS1",
            < 20000000 => "SSS2",
            < 25000000 => "SSS3",
            < 30000000 => "SSS4",
            < 36000000 => "SSS5",
            < 44000000 => "SSS6",
            < 52000000 => "SSS7",
            < 60000000 => "SSS8",
            < 70000000 => "SSS9",
            < 80000000 => "SSS10",
            < 90000000 => "SSS+1",
            < 105000000 => "SSS+2",
            < 125000000 => "SSS+3",
            < 145000000 => "SSS+4",
            < 165000000 => "SSS+5",
            < 185000000 => "SSS+6",
            < 205000000 => "SSS+7",
            < 225000000 => "SSS+8",
            < 250000000 => "SSS+9",
            < 500000000 => "SSS+10",
            _ => "X"
        };
    }
}
