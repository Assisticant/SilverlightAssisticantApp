Add the ViewModels namespace to App.xaml:

-- In Windows Store or Windows Phone applications:
<Application
	...
    xmlns:vm="using:SilverlightAssisticantApp.ViewModels">

-- In WPF or Silverlight applications:
<Application
	...
    xmlns:vm="clr-namespace:SilverlightAssisticantApp.ViewModels">


Add the view model locator to the resource dictionary:

    <Application.Resources>
        <ResourceDictionary>
			...
            <vm:ViewModelLocator x:Key="Locator"/>
        </ResourceDictionary>
    </Application.Resources>


Reference the view model locator in each view:

<Page
    ...
    DataContext="{Binding Main, Source={StaticResource Locator}}">
