using AutoMapper;
using Entities;
using Utilities.Dtos;
using Utilities.WeatherResponseModel;

namespace WeatherApi
{
    public class WeatherDataMapping:Profile
    {
        public WeatherDataMapping()
        {
            CreateMap<WeatherData, WeatherDataDto>();
            CreateMap<LocationData, LocationDataDto>();
            CreateMap<string, DateTime>().ConvertUsing(x => DateTime.Parse(x));

            CreateMap<ForecastModel, WeatherData>()
                .ForMember(dest => dest.TempFeelsLike, opt => opt.MapFrom(src => src.Main.FeelsLike))
                .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.Main.Temp))
                .ForMember(dest => dest.TempMin, opt => opt.MapFrom(src => src.Main.TempMin))
                .ForMember(dest => dest.TempMax, opt => opt.MapFrom(src => src.Main.TempMax))
                .ForMember(dest => dest.Pressure, opt => opt.MapFrom(src => src.Main.Pressure))
                .ForMember(dest => dest.SeaLevel, opt => opt.MapFrom(src => src.Main.SeaLevel))
                .ForMember(dest => dest.GroundLevel, opt => opt.MapFrom(src => src.Main.GroundLevel))
                .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity))
                .ForMember(dest => dest.TempKf, opt => opt.MapFrom(src => src.Main.TempKf))
                .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.Wind.Speed))
                .ForMember(dest => dest.WindDeg, opt => opt.MapFrom(src => src.Wind.Deg))
                .ForMember(dest => dest.WindGust, opt => opt.MapFrom(src => src.Wind.Gust))
                .ForMember(dest => dest.Visibility, opt => opt.MapFrom(src => src.Visibility))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateText))
                .ForMember(dest => dest.WeatherMain, opt => opt.MapFrom(src => src.Weather[0].Main))
                .ForMember(dest => dest.WeatherDescription, opt => opt.MapFrom(src => src.Weather[0].Description))
                .ForMember(dest => dest.RainValue3h, opt => opt.MapFrom(src => src.Rain.RainValue3h));


            CreateMap<Root, LocationData>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.City.Coord.Lat))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.City.Coord.Lon))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.City.Country))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.City.Population))
                .ForMember(dest => dest.TimeZone, opt => opt.MapFrom(src => src.City.Timezone))
                .ForMember(dest => dest.Sunrise, opt => opt.MapFrom(src => src.City.Sunrise))
                .ForMember(dest => dest.Sunset, opt => opt.MapFrom(src => src.City.Sunset))
                .ForMember(dest => dest.WeatherData, opt => opt.MapFrom(src => src.List));
        }
    }
}
