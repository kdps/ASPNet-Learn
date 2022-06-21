## Using

# Use Library

```
Microsoft.AspNetCore.Identity
RazorPagesIntro.Pages
```

```
@using Microsoft.AspNetCore.Identity
```

## Model

# Send Model To Page

```
@model LoginViewModel
```

## inject

# Dependency Inject

```
SignInManager<IdentityUser> SignInManager
UserManager<IdentityUser> UserManager
```

```
@inject SignInManager<UserStore> SignInManager
```
