*What code smells did you see?*

- Code complexity and opacity - in the whole Speaker class there was only one method Register() which was responsible for many things. 
This makes the code very hard to understand.
- Code duplication - not too much, but there were some checks which did the same job (checking for empty First Name, Last Name or Email)

*What problems do you think the Speaker class has?*

- It's written very complex and it's very difficult to get the logic of the method there. The register method probably should not be there,
because other service should be responsible for the registration of the speakers.
- Some variable names where very short and not informative.
- Too many blank lines make the file difficult to navigate

*Which clean code principles (or general programming principles) did it violate?*

- KISS - the code is definitely not simple
- YAGNI - some things from the code are not needed or can be read/extracted from other fields (HasBlog for example)
- The Single Responsibility Principle is alse violated because the single Register() method should take care of many things

*What refactoring techniques did you use?*

- Improved code readability
- Simplifying methods
- Renaming variables
- Extracting methods
- Encapsulating conditionals