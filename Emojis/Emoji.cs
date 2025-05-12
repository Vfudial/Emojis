namespace Emojis
{
    public class Emoji : IInit, IComparable<Emoji>, ICloneable
    {
        Random rnd = new Random();


        // Значения по умолчанию
        private string[] names =
        {
            "Улыбка",
            "Грусть",
            "Скука",
            "Смех",
            "Плач",
            "Кошкин хвост",
            "Куриная лапка",
            "Собака с вытянутым языком",
            "Орёл",
            "Смеющийся кот"
        };

        private string[] tags =
        {
            "Smile",
            "Sad",
            "Bored",
            "Laugh",
            "Cry",
            "Cat's_tale",
            "chicken_leg",
            "dog's_tongue",
            "eagle",
            "laughing_cat"
        };


        // Обозначение полей
        private string name;
        private string tag;
        public IdNumber Id { get; set; }

        // Свойства имени и тэга
        public string? Name
        {
            get => name;
            set => name = value ?? names[rnd.Next(names.Length)];
        }

        public string? Tag
        {
            get => tag;
            set
            {
                if (value != null)
                {
                    tag = value;
                }

                else
                {
                    tag = tags[rnd.Next(names.Length)];
                }
            }
        }

        // Конструкторы

        // По умолчанию
        public Emoji()
        {
            Id = new IdNumber();
            Name = names[0];
            Tag = tags[0];
        }

        // С параметрами
        public Emoji(int id, string name, string tag)
        {
            Id = new IdNumber(id);
            Name = name;
            Tag = tag;
        }

        // Копирования
        public Emoji(Emoji emoji)
        {
            Id = new IdNumber(emoji.Id);
            Name = emoji.Name;
            Tag = emoji.Tag;
        }

        public override string ToString()
        {
            return $"Id: {Id}. Эмодзи: {Name}, тэг: {Tag}";
        }

        public int CompareTo(Emoji? other)
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is Emoji other)
            {
                if (Name == other.Name && Tag == other.Tag)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode()^Tag.GetHashCode();
        }

        // Вывод
        public void Show()
        {
            Console.WriteLine($"Id: {Id}. Эмодзи: {Name}, тэг: {Tag}");
        }

        public virtual void Init()
        {
            Id = new IdNumber();
            Name = Inits.StringInput("Эмодзи");
            Tag = Inits.StringInput("тэг");
        }

        public virtual void RandomInit()
        {
            Id = new IdNumber();
            Name = names[rnd.Next(names.Length)];
            Tag = tags[rnd.Next(tags.Length)];
        }

        public object Clone()
        {
            return new Emoji(Id.Id, Name, Tag);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}