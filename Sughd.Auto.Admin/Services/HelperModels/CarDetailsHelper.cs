namespace Sughd.Auto.Admin.Services.HelperModels;

public static class CarDetailsHelper
{
    public static List<string> CarBody()
    {
        return new List<string>()
        {
            "Седан",
            "Хэтчбек",
            "Универсал",
            "Внедорожник",
            "Кроссовер",
            "Пикап",
            "Седан",
            "Минивен",
            "Фургон",
            "Кабриолет",
            "Купе",
            "Лифтбэк"
        };
    }

    public static List<string> Color()
    {
        return new List<string>()
        {
            "Белый",
            "Бежевый",
            "Серебристый",
            "Золотистый",
            "Жёлтый",
            "Оранжевый",
            "Красный",
            "Зелёный",
            "Голубой",
            "Синий",
            "Фиолетовый",
            "Коричневый",
            "Чёрный",
            "Другой цвет"
        };
    }

    public static List<string> FuelType()
    {
        return new List<string>()
        {
            "Бензин",
            "Бензин + газ",
            "Газ",
            "Дизель",
            "Электричество",
            "Гибрид",
            "Другой",
        };
    }

    public static List<string> Transmission()
    {
        return new List<string>()
        {
            "Механика",
            "Автомат",
            "Робот",
        };
    }
}