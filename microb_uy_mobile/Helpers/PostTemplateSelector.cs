
using microb_uy_mobile.DTOs;

namespace microb_uy_mobile.Helpers;
public class PostTemplateSelector : DataTemplateSelector
{
    public DataTemplate NormalPostTemplate { get; set; }
    public DataTemplate RepostPostTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is PostDto post)
        {
            if (post.TipoPost == "NORMAL")
            {
                return NormalPostTemplate;
            }
            else if (post.TipoPost == "REPOST")
            {
                return RepostPostTemplate;
            }
        }

        // Por defecto, utiliza la plantilla normal
        return NormalPostTemplate;
    }
}
