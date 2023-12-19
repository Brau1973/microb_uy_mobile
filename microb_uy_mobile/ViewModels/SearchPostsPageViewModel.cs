using microb_uy_mobile.DTOs;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MvvmHelpers;
using Refit;
using ObservableObject = Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject;

namespace microb_uy_mobile.ViewModels
{
    public partial class SearchPostsPageViewModel : ObservableObject
    {
        private readonly string BaseApiUrl = (string)App.SessionInfo["BaseUrl"];
        private readonly int TenantId = (int)App.SessionInfo["MainTenantId"];
        private readonly int LoggedUserId = (int)App.SessionInfo["LoggedUserId"];
        private readonly string UserToken = (string)App.SessionInfo["UserToken"];

        //-------------------------------- INFO PAGINADO --------------------------------
        //TODO ADAPTAR EL USO DE LASTID
        private int? _lastId;
        private int _pageSize = 10;
        private bool _hasMorePosts = true;
        private string _searchText;

        public ObservableRangeCollection<PostDto> PostList { get; set; } = new ObservableRangeCollection<PostDto>();

        //-------------------------------- OBSERVABLES PARA COMPORTAMIENTO DE LA VISTA --------------------------------

        [ObservableProperty]
        private string _labelMsg;

        [ObservableProperty]
        private bool _isLabelVisible;

        [ObservableProperty]
        private bool _isBusy = false;

        [ObservableProperty]
        private bool _isLoading = false;

        public SearchPostsPageViewModel()
        {
            IsLabelVisible = true;
            _labelMsg = "Busca Posts!";
        }

        // -------------------------------- METODOS --------------------------------
        private async Task<List<PostDto>> DownloadPostsAsync(int pageSize, string searchText)
        {
            var api = RestService.For<IPostService>(BaseApiUrl);
            var postResponse = await api.GetPaginatedPosts($"Bearer {UserToken}", TenantId, pageSize, _lastId, searchText, LoggedUserId, TenantId);

            if (postResponse?.Results != null && postResponse.Results.Any())
            {
                _lastId = postResponse.Results.Last().Id;
                _hasMorePosts = postResponse.Results.Count() == pageSize; // Corrección aquí
            }
            else
            {
                _hasMorePosts = false;
            }

            return postResponse?.Results.ToList() ?? new List<PostDto>();
        }

        [ICommand]
        public async Task GetPostList(string searchText)
        {
            _searchText = searchText;
            _lastId = null;
            _hasMorePosts = true;
            IsLoading = false;
            PostList.Clear();
            IsLoading = false;
            IsBusy = true;
            try
            {
                var results = await DownloadPostsAsync(_pageSize, _searchText);
                App.Current.Dispatcher.Dispatch(() =>
                {
                    IsBusy = false;
                    if (results.Count > 0)
                    {
                        IsLabelVisible = false;
                        PostList.ReplaceRange(results);
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
                Console.WriteLine($"Error en GetPostList: {ex}");
            }
        }

        [ICommand]
        public async Task LoadMoreData()
        {
            if (IsLoading || !_hasMorePosts) return;

            IsLoading = true;
            try
            {
                await Task.Delay(500);
                var results = await DownloadPostsAsync(_pageSize, _searchText);
                PostList.AddRange(results);
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