
namespace Emojis
{
    public class AnimalEmoji : Emoji, IInit, ICloneable
    {

        Random rnd = new Random();


        // Значения по умолчанию
        private string[] parts =
        {
            "Туловище",
            "Голова",
            "Передняя лапа",
            "Задняя лапа",
            "Ухо",
            "Хвост",
            "Язык",
            "Брюхо",
            "Целиком",
            "Зубы"
        };


        // Создание полей
        private string part;


        // Свойство
        public string? Part
        {
            get => part;
            set
            {
                if (value != null)
                {
                    part = value;
                }

                else
                {
                    part = parts[rnd.Next(part.Length)];
                };
            }
        }
        public Emoji GetBase
        {
            get => new Emoji(Id.Id, Name, Tag);
        }
        
        // Конструкторы
        // По умолчанию
        public AnimalEmoji() : base()
        {
            Part = parts[0];
        }
        // С параметрами
        public AnimalEmoji(int id, string name, string tag, string part) : base(id, name, tag)
        {
            Part = part;
        }
        // Копирования
        public AnimalEmoji(AnimalEmoji emoji) : base(emoji)
        {
            Part = emoji.Part;

        }


        public override string ToString()
        {
            return base.ToString() + $", часть тела: {Part}";
        }

        // Вывод
        public new void Show()
        {
            Console.WriteLine($"Эмодзи: {Name}, тэг: {Tag}, часть тела: {Part}");
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is AnimalEmoji other)
            {
                if (Name == other.Name && Tag == other.Tag && Part == other.Part)
                {
                    return true;
                }
            }
            return false;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Part.GetHashCode();
        }


        public override void Init()
        {
            base.Init();
            Part = Inits.StringInput("часть тела");
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Part = parts[rnd.Next(parts.Length)];

        }

        public object Clone()
        {
            return new AnimalEmoji(Id.Id, Name, Tag, Part);
        }
    }
}

