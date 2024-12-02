using HelloMauiDefault.Pages;
using HelloMauiDefault.ViewModels;

namespace HelloMauiDefault;

public partial class DetailsPageButXaml : BaseContentPage<DetailsViewModel>
{
	public DetailsPageButXaml(DetailsViewModel vm) : base(vm)
	{
		InitializeComponent();
	}
}