I used Visual studio  to create the ingridient project . 
The source code can be accessed through my zip file and running the code requires you to copy source code and run it using visual studio .
The code was submitted through GitHub.
https://github.com/NtokozoNDJ/NewRepo.git

Brief description
The code was modified in response to the lecturer's criticism in order to fix the problems with storing ingredients and stages in arrays, which led to an array size error that crashed the application. The code now stores ingredients and actions in generic collections (List<T>) rather than arrays. This modification removes the possibility of crashes caused by array size and permits dynamic resizing.

Furthermore, rather than retaining a single recipe instance, the application now allows many recipes by keeping track of a List<Recipe>. Users may now enter, store, and manage multiple recipes thanks to this. Every recipe has a name, steps, and ingredients.

I've added thorough comments for clarity, and the code structure is still well-organized. Techniques for inputting recipe information, presenting a recipe collection, and choosing a recipe to showcase have been put into place. The user experience is improved by having the recipes arranged alphabetically. These modifications respect the input received while ensuring the stability and usefulness of the program.

