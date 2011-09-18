﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace D3SharpDatabase
{

    public class Hero_Details 
    {
        public int Id { get; private set; }
        public int Title_Id { get; set; }
        public int BlockAmount { get; set; }
        public int BlockChance { get; set; }
        public int DodgeChance { get; set; }
        public int DamageReduction { get; set; }
        public int AttackDamageBonus { get; set; }
        public int PrecisionCritBonus{ get; set; }
        public int DefenseDamageReduction { get; set; }
        public int VitalityLife { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }
        public int Precision { get; set; }
        public int Defense { get; set; }
        public int Vitality { get; set; }
        public int DamageIncrease { get; set; }
        public int AttacksPerSecond  { get; set; }
        public int CritDamageBonus { get; set; }
        public int CritChanceBonus { get; set; }
        public int CastingSpeed { get; set; }
        public int LifePerKill { get; set; }
        public int LifePerHit { get; set; }
        public int MovementSpeed { get; set; }
        public int GoldFind { get; set; }
        public int Life { get; set; }
        public int LifePerSecond { get; set; }
        public int LifeSteal { get; set; }
        public int MagicFind { get; set; }
        public int FuryGain { get; set; }
        public int SpiritGain { get; set; }
        public int ManaGain { get; set; }
        public int ArcanumGain { get; set; }
        public int HatredGain { get; set; }
        public int DisciplineGain { get; set; }
        public int MaxMana { get; set; }
        public int MaxArcanum { get; set; }
        public int MaxHatred { get; set; }
        public int MaxFury { get; set; }
        public int MaxDiscipline { get; set; }
        public int MaxSpirit { get; set; }

        public Hero_Details (int title_id, int blackamount, 
                             int blockchance, int dodgechance, 
                             int damagereduction, int attackbonusdamage, 
                             int precisioncritbonus, 
                             int defensedamagereduction, int vitalitylife,
                             int armor, int attack, int precision,
                             int defense, int vitality,
                             int damageincrease, int attackspersecond,
                             int critdamagebonus, int critchancebonus,
                             int castingspeed, int lifeperkill,
                             int lifeperhit, int movementspeed,
                             int goldfind, int life, int lifepersecond, 
                             int lifesteal, int magicfind, int furygain, 
                             int spiritgain, int managain, 
                             int arcanumgain, int hatredgain, 
                             int disciplinegain, int maxmana, 
                             int maxarcanum, int maxhatred,
                             int maxfury, int maxdiscipline,
                             int maxspirit)
        {
            Id = -1;
            Title_Id = title_id;
            BlockAmount = blackamount;
            BlockChance = blockchance;
            DodgeChance = dodgechance;
            DamageReduction = damagereduction;
            AttackDamageBonus = attackbonusdamage;
            PrecisionCritBonus = precisioncritbonus;
            DefenseDamageReduction = defensedamagereduction;
            VitalityLife = vitalitylife;
            Armor = armor;
            Attack = attack;
            Precision = precision;
            Defense = defense;
            Vitality = vitality;
            DamageIncrease = damageincrease;
            AttacksPerSecond = attackspersecond;
            CritDamageBonus = critdamagebonus;
            CritChanceBonus =critchancebonus;
            CastingSpeed = castingspeed;
            LifePerKill = lifeperkill;
            LifePerHit = lifeperhit;
            MovementSpeed = movementspeed;
            GoldFind = goldfind;
            Life = life;
            LifePerSecond = lifepersecond;
            LifeSteal = lifesteal;
            MagicFind = magicfind;
            FuryGain = furygain;
            SpiritGain = spiritgain;
            ManaGain = managain;
            ArcanumGain = arcanumgain;
            HatredGain = hatredgain;
            DisciplineGain = disciplinegain;
            MaxMana = maxmana;
            MaxArcanum = maxarcanum;
            MaxHatred = maxhatred;
            MaxFury = maxfury;
            MaxDiscipline = maxdiscipline;
            MaxSpirit = maxspirit;
        }



        public bool Save()
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(string.Format("UPDATE account_banner SET background_color='{1}', banner='{2}', pattern='{3}', pattern_color='{4}', placement='{5}', signil_accent='{6}', signil_main='{7}', signil_color='{8}', use_signil_variant='{9}' WHERE account_id='{0}'", Id,BackgroundColor,Banner,Pattern,PatternColor,Placement,SignilAccent,SignilMain,SignilColor,UseSignilVariant), Database.Instance.Connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save Account Banner exception: {0}", e.Message);
                return false;
            }
        }

        public bool Create()
        {
            SQLiteCommand command = new SQLiteCommand(string.Format("INSERT INTO account_banner (account_id, background_color, banner, pattern, pattern_color, placement, signil_accent, signil_main, signil_color, use_signil_variant) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", Id, BackgroundColor, Banner, Pattern, PatternColor, Placement, SignilAccent, SignilMain, SignilColor, UseSignilVariant), Database.Instance.Connection);
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows == 0)
                return false;
            Id = Database.Instance.GetLastInsertId();
            return true;
        }


        public static bool Load(int id, out AccountBanner accountbanner)
        {
            accountbanner = null;
            SQLiteCommand command = new SQLiteCommand(string.Format("SELECT * FROM account_banner WHERE account_id='{0}'", id), Database.Instance.Connection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    accountbanner = new AccountBanner(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetString(8), reader.GetBoolean(9));
                    return true;
                }
            }
            return false;
        }

        

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}", Id, BackgroundColor,Banner,Pattern,PatternColor,Placement,SignilAccent,SignilMain,SignilColor,UseSignilVariant);
        }
    }
}

















 Details & Settings 
Help CodeViewer.org stay ad-free, and become better. 
 

Code Viewer ©2007; founder Daniel M. Story.
The content presented on this site is copyrighted material to its rightful author.

Powered By: GeSHi, mootools