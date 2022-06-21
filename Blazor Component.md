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
