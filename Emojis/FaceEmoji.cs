using System;
using System.Xml.Linq;
using Emojis;

namespace Emojis
{
    public class FaceEmoji : Emoji, IInit, ICloneable
    {
        Random rnd = new Random();

        // Значения по умолчанию
        private string[] images = { ":-)", ":-(", "-_-", ":D", ":_(", "~~~", "/|\'", ":P", ">=|*>", "=^.^=" };

        // Поля по умолчанию
        private string image;
        private int power;

        // Свойства
        public string Image
        {
            get => image;
            set
            {
                if (value != null)
                {
                    image = value;
                }

                else
                {
                    image = images[rnd.Next(image.Length)];
                };
            }
        }

        public int Power
        {
            get => power;
            set
            {
                if (value < 0 || value > 10)
                {
                    power = 10;
                }

                else
                {
                    power = value;
                };

            }
        }

        // Конструкторы
        // По умолчанию
        public FaceEmoji() : base()
        {
       
            this.Image = images[0];
            this.Power = 5;
        }

        // С параметрами
        public FaceEmoji(int id, string name, string tag, string image, int power) : base(id, name, tag)
        {
            this.Image = image;
            this.Power = power;
        }

        // Копирования
        public FaceEmoji(FaceEmoji emoji) : base(emoji)
        {
            this.Image = emoji.Image;
            this.Power = emoji.Power;

        }

        public override string ToString()
        {
            return base.ToString() + $", выражение: {Image}, сила эмодзи: {Power}";
        }

        // Вывод
        public new void Show()
        {
            Console.WriteLine($"Эмодзи: {Name}, тэг: {Tag}, выражение: {Image}, сила эмодзи: {Power}");
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is FaceEmoji other)
            {
                if (Id == other.Id && Name == other.Name && Tag == other.Tag && Image == other.Image && Power == other.Power)
                {
                    return true;
                }

            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()^Image.GetHashCode()^Power.GetHashCode();
        }

        public override void Init()
        {
            base.Init();
            Image = Inits.StringInput("эмодзи");
            Power = Inits.IntInput("эмодзи", 0, 10);
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Image = images[rnd.Next(images.Length)];
            Power = rnd.Next(0,11);
        }

        public object Clone()
        {
            return new FaceEmoji(Id.Id, Name, Tag, Image, Power);
        }
    }
}