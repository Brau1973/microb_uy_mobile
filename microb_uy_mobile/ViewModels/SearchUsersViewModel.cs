using microb_uy_mobile.DTOs;
using microb_uy_mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmHelpers;
using Refit;
using ObservableObject = Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject;

namespace microb_uy_mobile.ViewModels
{
    public partial class SearchUsersViewModel : ObservableObject
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];
        private readonly string UserToken = (string)App.SessionInfo["UserToken"];

        //-------------------------------- INFO PAGINADO --------------------------------
        private int _firstPage = 1;
        private int _pageSize = 10;
        private int _currentPage = 1;
        private string _searchText;

        //------------------------------------------------- LISTA ------------------------------------------------
        public ObservableRangeCollection<UserDto> UsersList { get; set; } = new ObservableRangeCollection<UserDto>();

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
        public SearchUsersViewModel()
        {
            IsLabelVisible = true;
            _labelMsg = "Busca Usuarios!";
        }

        // -------------------------------- METODOS --------------------------------
        private async Task<List<UserDto>> DownloadUsersAsync(int page, int pageSize, string searchText)
        {
            var api = RestService.For<IUsuariosService>(BaseApiUrl);
            var usuariosResponse = await api.GetUsuarios($"Bearer {UserToken}", TenantId, page, pageSize, searchText);
            return usuariosResponse?.Response.Results.ToList() ?? new List<UserDto>();
        }

        [ICommand]
        public async Task GetUsersList(string searchText)
        {
            _searchText = searchText;
            _currentPage = 1;
            UsersList.Clear();
            IsBusy = true;
            try
            {
                var results = await DownloadUsersAsync(_firstPage, _pageSize, searchText);
                App.Current.Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;
                    if (results.Count > 0)
                    {
                        IsLabelVisible = false;
                        UsersList.ReplaceRange(results);
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
                Console.WriteLine($"Error en GetUsersList: {ex}");
            }
        }

        [ICommand]
        public async Task LoadMoreData()
        {
            if (IsLoading) return;

            if (UsersList?.Count > 0)
            {
                try
                {
                    IsLoading = true;
                    await Task.Delay(500);
                    var results = await DownloadUsersAsync(_currentPage + 1, _pageSize, _searchText);
                    IsLoading = false;
                    UsersList.AddRange(results);
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
