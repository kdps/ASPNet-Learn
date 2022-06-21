# ContextMenu
```
services.AddScoped<ContextMenuService>();
```

```
@inject ContextMenuService contextMenuService

<RadzenButton Text="Show context menu with items for Radzen component" ContextMenu="@(args => ShowContextMenuWithItems(args))" />
<RadzenButton Text="Show context menu with custom content for Radzen component" ContextMenu="@(args => ShowContextMenuWithContent(args) )" />
<button @oncontextmenu="@(args => ShowContextMenuWithContent(args))" @oncontextmenu:preventDefault="true">
    Show context menu with custom content for HTML element
</button>

@code {
    void ShowContextMenuWithItems(MouseEventArgs args)
    {
        contextMenuService.Open(args,
            new List<ContextMenuItem>() {
                new ContextMenuItem(){ Text = "Context menu item 1", Value = 1 },
                new ContextMenuItem(){ Text = "Context menu item 2", Value = 2 },
                new ContextMenuItem(){ Text = "Context menu item 3", Value = 3 },
         }, OnMenuItemClick);
    }

    void ShowContextMenuWithContent(MouseEventArgs args) => contextMenuService.Open(args, ds =>
        @<RadzenMenu Click="OnMenuItemClick">
            <RadzenMenuItem Text="Item1" Value="1"></RadzenMenuItem>
            <RadzenMenuItem Text="Item2" Value="2"></RadzenMenuItem>
            <RadzenMenuItem Text="More items" Value="3">
                <RadzenMenuItem Text="More sub items" Value="4">
                    <RadzenMenuItem Text="Item1" Value="5"></RadzenMenuItem>
                    <RadzenMenuItem Text="Item2" Value="6"></RadzenMenuItem>
                </RadzenMenuItem>
            </RadzenMenuItem>
            </RadzenMenu>
        );

    void OnMenuItemClick(MenuItemEventArgs args)
    {
        //
    }
}
```


# Tooltip

```
services.AddScoped<TooltipService>();
```

```
@inject TooltipService tooltipService

<RadzenTooltip />

<RadzenButton Text="Show tooltip with text" MouseEnter="@(args => ShowTooltip(args) )" />
<RadzenButton Text="Show tooltip with custom content" MouseEnter="@(args => ShowTooltipWithHtml(args, new TooltipOptions(){ Style = "color:#000", Duration = null }))" />
<button @ref="htmlButton" @onmouseover="@(args => ShowTooltip(htmlButton))">
    Show tooltip
</button>

@code {
    ElementReference htmlButton;

    void ShowTooltip(ElementReference elementReference, TooltipOptions options = null) => tooltipService.Open(elementReference, "Some content", options);

    void ShowTooltipWithHtml(ElementReference elementReference, TooltipOptions options = null) => tooltipService.Open(elementReference, ds =>
@<div>
    Some <b>HTML</b> content
</div>, options);
}
```

# Notification

```
services.AddScoped<NotificationService>();
```

```
@inject NotificationService notificationService

<RadzenNotification />

<RadzenButton Text="Show success notification" 
            Click="@(args => ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = "Success Summary", Detail = "Success Detail", Duration = 4000 }))" />
```

# Dialog

```
services.AddScoped<DialogService>();
```

```
@inject DialogService dialogService

<RadzenDialog />

<RadzenButton Text=@($"Show OrderID: {orderID} details") Click="@(args => dialogService.Open<DialogCardPage>($"Order {orderID}",
                        new Dictionary<string, object>() { { "OrderID", orderID } },
                        new DialogOptions(){ Width = "700px", Height = "530px", Left = "calc(50% - 350px)", Top = "calc(50% - 265px)" }))" />
```

# Table

```
TableTemplate(Items => List, TItem => Typeof List)
TableHeader > th
RowTemplate (Context => Class) > td
```

# InputFile

<InputFile OnChange="@LoadFiles" multiple />

```
@code {
    private void LoadFiles(InputFileChangeEventArgs e)
    {
    }
}
```
