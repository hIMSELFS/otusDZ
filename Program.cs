
LogicGame Game = new LogicGame();

Game.Start();


class LogicGame
{
    int MaxPoint;
    int MaxRange;
    int MinRange;
    int secret;
    int tryPoint = 1;

    public void Start()
    {
        this.GetParams("MaxPoint");
        this.GetParams("MaxRange");
        this.GetParams("MinRange");
        this.secret = new Random().Next(MinRange, MaxRange);

        Console.WriteLine($"Я загадал число {this.secret} в радиусе [{MinRange};{MaxRange}].\nПопробуй угадать за {MaxPoint} попыток");

        Boolean result = this.Play();

        if (!result)
        {
            Console.WriteLine($"Ты не угадал. Я загадал число:  {this.secret} ");
            return;
        }
        Console.WriteLine($"Ты угадал! Я загадал число:  {this.secret} ");
        return;

    }
    
    private Boolean Play()
    {
        if (this.MaxPoint < this.tryPoint)
        {
            return false;
        }
        
        try
        {
            Console.Write($"(Попытка#{this.tryPoint}/{this.MaxPoint})Введите число: ");
            int? point = Convert.ToInt32(value: Console.ReadLine());
            if (point == this.secret)
            {
                return true;
            }
            if(point < this.secret)
            {
                Console.WriteLine("Загаданное число больше!");
                this.tryPoint += 1;
                this.Play();
            }
            if( point > this.secret)
            {
                Console.WriteLine("Загаданное число меньше!");
                this.tryPoint += 1;
                this.Play();
            }
            return true;
        }
        catch(FormatException)
        {
            Console.WriteLine("Некорректный ввод...");
            this.Play();
            return false;
        }
        catch(OverflowException )
        {
            Console.WriteLine("Некорректный ввод...");
            this.Play();
            return false;
            
        }
        
       
    }
    
    private void GetParams(string param)
    {
        try
        {
            if (param == "MaxPoint")
            {
                Console.Write("Введи количество максимальных попыток: ");
                int result = Convert.ToInt32(Console.ReadLine());
                this.MaxPoint = result;
                return;
            }
            if (param == "MaxRange")
            {
                Console.Write("Введи максимальный рейндж: ");
                int result = Convert.ToInt32(Console.ReadLine());
                this.MaxRange = result;
                return;
            }
            if (param == "MinRange")
            {
                Console.Write("Введи минимальный рейндж: ");
                int result = Convert.ToInt32(Console.ReadLine());
                this.MinRange = result;
                return;
            }
        }
      
        catch
        {
            Console.WriteLine($"Некорректный ввод параметра {param} ...");
            this.GetParams(param);
            return ;
        }
        return;
    }
}


