using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services;
using Refit;
using System.Collections.ObjectModel;

namespace microb_uy_mobile.ViewModels
{
    internal class MainPageViewModel
    {
        public ObservableCollection<DefaultReponseDTO> Instancias { get; set; } = new();
        IInstanciaService iinstanciaService;

        public MainPageViewModel()
        {
            //iinstanciaService = RestService.For<IInstanciaService>("https://10.0.2.2:5001");
            //new Action(async () => await LoadData())();
        }

        async Task LoadData()
        {
            var Instancias = await iinstanciaService.GetInstanciasAsync();

            foreach (var instanciasItem in Instancias)
            {
                this.Instancias.Add(instanciasItem);
            }
        }

        //Instancias = new ObservableCollection<InstanciaDTO>();
        //apiService = new InstanciaService();

        //Task.Run(async () => await LoadDataFromApiAsync());

        //Instancias = new ObservableCollection<InstanciaDTO>
        //{
        //    new InstanciaDTO("Futbol", "diego_forlan.jpg", "URL"),
        //    new InstanciaDTO("Politica", "diego_forlan.jpg", "URL"),
        //    new InstanciaDTO("Tech", "diego_forlan.jpg", "URL"),
        //    new InstanciaDTO("Bares", "diego_forlan.jpg", "URL"),
        //    new InstanciaDTO("Trabajos", "diego_forlan.jpg", "URL"),
        //    new InstanciaDTO("Vacaciones", "diego_forlan.jpg", "URL")
        //};
    //}

        //private async Task LoadDataFromApiAsync()
        //{
        //    var instancias = await apiService.GetInstanciasAsync();
        //    Console.WriteLine("Volvi de apiService.GetInstanciasAsync()");
        //    if (instancias != null)
        //    {
        //        foreach (var instancia in instancias)
        //        {
        //            Instancias.Add(instancia);
        //        }
        //    }
        //}
    }

}
