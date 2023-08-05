using Autofac;
using Quran.Core;
using Quran.Core.Extention;
using Quran.UI.Data;
using Quran.UI.ViewModels;

namespace Quran.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<QuranLoader>().AsSelf().AsImplementedInterfaces().SingleInstance();

            //builder.RegisterType<MainDataModel>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            //builder.RegisterType<SuraNamesLoader>().AsImplementedInterfaces();
            builder.RegisterType<GeneralConverter>().AsImplementedInterfaces();

            builder.RegisterType<SingleSequanceDataModel>().AsImplementedInterfaces();
            builder.RegisterType<TwoVerseComparisonViewModel>().AsImplementedInterfaces();
            builder.RegisterType<SearchInVerseViewModel>().AsImplementedInterfaces();
            builder.RegisterType<SearchInVerseDataModel>().AsImplementedInterfaces();

            builder.RegisterType<SingleSequanceViewModel>().AsSelf().AsImplementedInterfaces();
            
            return builder.Build();
        }
    }
}
