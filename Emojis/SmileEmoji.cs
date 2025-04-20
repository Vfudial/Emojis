namespace Emojis
{
    public class SmileEmoji : FaceEmoji, IInit, ICloneable
    {

        Random rnd = new Random();


        // Значения по умолчанию
        private string[] reasons =
        {
            "Погода", 
            "Победа", 
            "Друзья", 
            "Любовь", 
            "Сюрприз", 
            "Музыка", 
            "Оценка", 
            "Путешествие", 
            "Подарок",
            "Воспоминание"
        };


        // Создание полей
        private string reason;


        // Свойство
        public string Reason
        {
            get => reason;
            set
            {
                if (value != null)
                {
                    reason = value;
                }

                else
                {
                    reason = reasons[rnd.Next(reasons.Length)];
                };
            }
        }

        // Конструкторы

        // По умолчанию
        public SmileEmoji() : base()
        {

            this.Reason = reasons[0];
        }

        // С параметрами
        public SmileEmoji(int id, string name, string tag, string image, int power, string reason) : base(id, name, tag, image, power)
        {
            this.Reason = reason;
        }

        // Копирования
        public SmileEmoji(SmileEmoji emoji) : base(emoji)
        {
            this.Reason = emoji.Reason;

        }


        public override string ToString()
        {
            return base.ToString() + $", причина улыбки: {this.Reason}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is SmileEmoji other)
            {
                if (Id == other.Id && Name == other.Name && Tag == other.Tag && Image == other.Image && Power == other.Power && Reason == other.Reason)
                {
                    return true;
                }
            }
            return false;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Reason.GetHashCode();
        }

        // Вывод
        public new void Show()
        {
            Console.WriteLine($"Эмодзи: {Name}, тэг: {Tag}, выражение: {Image}, сила эмодзи: {Power}, причина улыбки: {Reason}");
        }

        public override void Init()
        {
            base.Init();
            Reason = Inits.StringInput("причина");

        }

        public override void RandomInit()
        {
            base.RandomInit();
            Reason = reasons[rnd.Next(reasons.Length)];
        }
    }
}

