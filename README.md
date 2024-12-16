# ООП. Лабораторная работа №3. перегрузка операций, вариант 13
## Постановка задачи
Задание 1. Реализовать определение класса (поля, свойства,
конструкторы, перегрузка метода ToString() для вывода полей, заданный
метод согласно варианту). Протестировать все методы, включая
конструкторы, не забывайте проверять вводимые пользователем данные
на корректность!

Задание 2. Добавить к реализованному в первом задании классу
указанные в варианте перегруженные операции. Протестировать все
методы

## Класс Money
## Поля
Класс содержит поля:
```c#
private uint rubles;
private byte kopeks;
```

## Конструкторы
Конструктор **по умолчанию** инициализирует пустой кошелек:

```c#
public Money() // Конструктор по умолчанию
{
    rubles = 0;
    kopeks = 0;
}
```

Конструктор **с параметрами** инициализирует кошелек с переданными значениями:

```c#
public Money(uint rubles, byte kopeks)
{
    this.rubles = rubles;
    this.kopeks = kopeks;
}
```

**конструктор копирования**:

```c#
public Money(Money money) // Конструктор копирования
{
    rubles = money.rubles;
    kopeks = money.kopeks;
}
```

## Методы

Ниже преставлены реализованные **методы** класса **Money**:

```c#
public override string ToString() {...}; //перегруженный ToString(), возвращает рубли и копейки

//перегрузка оператора вычитания, возвращает объект типа Money
public static Money operator -(Money money, uint kopeks) {...};
public static Money operator -(uint kopeks, Money money) {...};
public static Money operator -(Money money1, Money money2) {...};

//перегрузка оператора сложения, возвращает объект типа Money
public static Money operator +(Money money, uint kopeks) {...};

//перегрузка унарных операторов -- и ++, возвращает объект типа Money
public static Money operator --(Money money) {...};
public static Money operator ++(Money money) {...};

public static Money operator --(Money money) {...}; //явное преобразование в тип uint, возвращает рубли
public static Money operator ++(Money money) {...}; //неявное преобразование в тип bool, вовзращает true если деньги есть

// Геттеры
public uint Rubles {...};
public byte Kopeks {...};
```

пример перегрузки оператора на вычитании
```c#
public static Money operator -(Money money, uint kopeks)
{
    // проверяем, что при вычитании количество денег не уйдет в минус, иначе возвращаем пустой кошелек
    if (100 * money.rubles + money.kopeks > kopeks) 
    {
        // переводим рубли в копейки и складываем с имеющимися копейками, вычитаем
        // результат целочислено делим на 100 и получаем целую часть, тоесть рубли
        // для копеек используя метод из 1 задания 1 лабы, получаем вещественную часть числа и умножаем на 100, таким образом получая копейки 
        return new Money((100 * money.rubles + money.kopeks - kopeks) / 100, 
                   (byte)(100 * LabMath.fraction((decimal)(money.rubles * 100 + money.kopeks - kopeks) / 100)));
    }
    return new Money(0, 0);
}
```

## Класс MainWindow
## Поля
Класс содержит поля:
```c#
private bool isDarkTheme = true; // 0 - light, 1 - dark
```

## Конструкторы
Конструктор **по умолчанию**:

```c#
public MainWindow()
{
    InitializeComponent();

    if (File.Exists("data.dat"))
    {
        StreamReader f = new StreamReader("data.dat");
        try { isDarkTheme = bool.Parse(f.ReadLine()); }
        catch { isDarkTheme = true; }
        f.Close();
    }
    ChangeTheme();
}
```

## Методы

```c#
void DataWindow_Closing(object sender, CancelEventArgs e)

private void Show_Result_Click(object sender, RoutedEventArgs e)
private void DarkLightToggle_Click(object sender, RoutedEventArgs e)

private void ChangeTheme()
```

# Вариант темной темы
![image](https://github.com/user-attachments/assets/b73349d5-249a-4a30-b257-ee5f2f03504f)

# Вариант светлой темы
![image](https://github.com/user-attachments/assets/2792d669-647a-47a6-89da-a087f3b4c6b2)

## Тесты

# Если пользователь успешно ввел значения рублей и копеек

*Вывод:*
![image](https://github.com/user-attachments/assets/123427d4-f784-40f6-8c2a-c9c446d00152)

# Если пользователь ввел некорректные значения рублей и копеек

*Вывод:*
![image](https://github.com/user-attachments/assets/5a3c92dd-eb3d-4ca8-9146-3d32f4708254)
![image](https://github.com/user-attachments/assets/58b117d9-a61a-469e-bb52-22d0e2bcaa2c)
![image](https://github.com/user-attachments/assets/3e438b09-a482-4e05-88ab-c7978cda550f)


