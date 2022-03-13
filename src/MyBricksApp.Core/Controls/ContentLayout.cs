using Xamarin.Forms;

namespace MyBricksApp.Core.Controls
{
    [ContentProperty(nameof(Content))]
    public sealed class ContentLayout : StackLayout
    {
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(
            propertyName: nameof(Content),
            returnType: typeof(View),
            declaringType: typeof(ContentLayout),
            defaultValue: default(View));

        public View Content
        {
            get => (View) GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
    }
}