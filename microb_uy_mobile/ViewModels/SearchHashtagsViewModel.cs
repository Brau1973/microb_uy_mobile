using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmHelpers;
using Refit;
using ObservableObject = Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject;

namespace microb_uy_mobile.ViewModels
{
    public partial class SearchHashtagsViewModel : ObservableObject
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];

        //-------------------------------- INFO PAGINADO --------------------------------
        private int _firstPage = 1;
        private int _pageSize = 10;
        private int _currentPage = 1;
        private string _searchText;

        //------------------------------------------------- LISTA ------------------------------------------------
        public ObservableRangeCollection<HashTagDto> HashTagList { get; set; } = new ObservableRangeCollection<HashTagDto>();

        //-------------------------------- OBSERVABLES PARA COMPORTAMIENTO DE LA VISTA --------------------------------

        [ObservableProperty]
        private string _labelMsg;

        [ObservableProperty]
        private bool _isLabelVisible;

        [ObservableProperty]
        private bool _isBusy = false;

        [ObservableProperty]
        private bool _isLoading = false;

        // -------------------------------- CONSTRUCTOR --------------------------------
        public SearchHashtagsViewModel()
        {
            IsLabelVisible = true;
            _labelMsg = "Busca Hashtags!";
        }

        // -------------------------------- METODOS --------------------------------
        private async Task<List<HashTagDto>> DownloadHashTagsAsync(int page, int pageSize, string searchText)
        {
            var api = RestService.For<IHashTagService>(BaseApiUrl);
            var hashtagResponse = await api.GetHashtags(TenantId, page, pageSize, searchText);
            return hashtagResponse?.Response.Results.ToList() ?? new List<HashTagDto>();
        }

        [ICommand]
        public async Task GetHashTagList(string searchText)
        {
            _searchText = searchText;
            _currentPage = 1;
            HashTagList.Clear();
            IsBusy = true;
            try
            {
                var results = await DownloadHashTagsAsync(_firstPage, _pageSize, searchText);
                App.Current.Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;
                    if (results.Count > 0)
                    {
                        IsLabelVisible = false;
                        HashTagList.ReplaceRange(results);
                    }
                    else
                    {
                        IsLabelVisible = true;
                        LabelMsg = "No hay resultados para tu busqueda!";
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GetHashTagList: {ex}");
            }
        }

        [ICommand]
        public async Task LoadMoreData()
        {
            if (IsLoading) return;

            if (HashTagList?.Count > 0)
            {
                try
                {
                    IsLoading = true;
                    await Task.Delay(500);
                    var results = await DownloadHashTagsAsync(_currentPage + 1, _pageSize, _searchText);
                    IsLoading = false;
                    HashTagList.AddRange(results);
                    _currentPage++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en LoadMoreData: {ex}");
                }
                finally
                {
                    IsLoading = false;
                }
            }
        }
    }
}
