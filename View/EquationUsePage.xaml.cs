using AngouriMath;
using ProjektTales.ViewModels;

namespace ProjektTales;

public partial class EquationUsePage : ContentPage
{
    public EquationUsePage(EquationUseViewModel equationUseViewModel)
	{
		InitializeComponent();
        BindingContext = equationUseViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    
    Entity selectedExpr;
    EquationStats es;
    Entry selectedEntry;
    Dictionary<string, string> variables = new();

    private void Calculate_Clicked(object sender, EventArgs e)
    {
        Entity createdExpr = selectedExpr;
        
        foreach (var pair in variables)
        {
            string val = pair.Value;
            
            if (pair.Value.StartsWith('*') || pair.Value.EndsWith('*'))
                val = val.Replace('*', ' ');
            if (pair.Value.StartsWith('/') || pair.Value.EndsWith('/'))
                val = val.Replace('/', ' ');
            
            Entity toEvaluate = val;
            if (toEvaluate.EvaluableNumerical)
                createdExpr = createdExpr.Substitute(pair.Key, toEvaluate.EvalNumerical());
            else
                createdExpr = createdExpr.Substitute(pair.Key, pair.Value);
        }
        
        if (createdExpr.EvaluableNumerical)
            result.Text = $"{selectedExpr} | {createdExpr} | odp: {createdExpr.EvalNumerical()}";
        else
            result.Text = "Expression is not evaluable";
    }

    private void Insert_Symbol(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (selectedEntry.Text.Length != 0 && !selectedEntry.Text.Contains(clickedButton.Text))
            selectedEntry.Text += clickedButton.Text;
        else
            return;
    }

    private void Set_Current_Entry(object sender, FocusEventArgs e)
    {
        Entry entry = (Entry)sender;

        if (selectedEntry is null || selectedEntry != entry)
            selectedEntry = entry;
    }

    private void Entry_Changed(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        string variable = entry.Placeholder;
        
        if (variables.ContainsKey(variable))
            variables[variable] = entry.Text;
        else
            variables.Add(variable, entry.Text);
    }

    private void Page_Loaded(object sender, EventArgs e)
    {
        ContentPage page = (ContentPage)sender;
        EquationUseViewModel useViewModel = (EquationUseViewModel)page.BindingContext;
        es = useViewModel.EquationStats;
        selectedExpr = es.MathExpression;
    }
}