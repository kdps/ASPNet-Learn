# Code

```
@code {
}
```

## onclick

### Add OnClick Event Listener

```
<a>@currentCount</a>
<a @onclick="IncrementCount">ClickEvent</a>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```


# Header

## inherits

### Set Base Class

```
@inherits BlazorRocksBase
```

## Page

### Indicates that template is blazor

```
@page
```

## Using

### Use Library

```
Microsoft.JSInterop
Microsoft.AspNetCore.Identity
Microsoft.AspNetCore.Authorization
Microsoft.AspNetCore.Components.Authorization;
Microsoft.AspNetCore.Components.Forms;
Microsoft.AspNetCore.Components.Routing;
Microsoft.AspNetCore.Components.Web;
Microsoft.AspNetCore.Components.Web.Virtualization;
RazorPagesIntro.Pages
BlazorSample.Components
```

```
@using Microsoft.AspNetCore.Identity
```

## Model

### Send Model To Page

```
@model LoginViewModel
```

## inject

### Dependency Inject

```
SignInManager<IdentityUser> SignInManager
UserManager<IdentityUser> UserManager
```

```
@inject SignInManager<UserStore> SignInManager
```
