# Coding Kata ToDictionary
coding kata to convert a given input string e.g "a=1;b=2" into a list of tuples splited by ';' and '=' symbol result [("a", "1"), ("b", "2")]

```csharp
IDictionary<string, string> ToDictionary(string input);
```
The following table shows some examples for input strings and the resulting dictionary.

| input           | output                          |
| --------------- | ------------------------------- |
| `"a=1;b=2;c=3"` | `{'a': '1','b': '2','c': '3'}`  |
| `"a=1;a=2"`     | `{'a': '2'}`                    |
| `"a=1;;b=2"`    | `{'a': '1','b': '2'}`           |
| `"a="`          | `{'a': ''}`                     |
| `"=2"`          | Exception                       |
| `""`            | `{}                             |
| `"a==1"`        | `{'a', '=1'}`                   |

Please find further information [Coding Kata ToDictionary](https://ccd-school.de/coding-dojo/function-katas/todictionary/)

* Please use git to clone the repo
  
* To restore nuget packages paket will help you ;), Therefore please restore needed tools.
```powershell
> dotnet tool restore
```
* Restore nuget package references. (Root Folder) 
```powershell
> dotnet restore
```
* Execute the tests either for C# or F# navigate to the folder and execute. Dotnet test builds and executes the tests in one command.
```powershell
> dotnet test
```
And if everything goes well, you get a result on the CLI that all 7 tests were successful.