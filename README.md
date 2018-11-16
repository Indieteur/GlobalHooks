# Global Hooks
Allows you to listen for Global Keyboard and Mouse events so even if your application is inactive, it'll still capture Mouse and Keyboard input. This can be used to make global keyboard shortcuts for example.

# Compatibility
This library was made using Visual Studio 2017 so you need to have that to be able to use this. Also, the library might not be compatible with lower versions of VS.

# How to Use
There is a Demo project included which shows you how to use the library. The events, enumerations, types, properties and whatnot also have summarized descriptions so you can use the object browser to learn more about them. 

# License
This library is licensed under [CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication](https://creativecommons.org/publicdomain/zero/1.0/). Also, no need to credit me by the way but if you do, please credit me as Indieteur and if you can, please include my [website](https://indieteur.com) as well. (e.g. `GlobalHooks by Indieteur - https://indieteur.com`)

# How do I support you by the way?
You can support me through [Patreon](https://www.patreon.com/indieteur). Thank you!

# Credits
* [Siarhei Kuchuk](https://stackoverflow.com/users/212746/siarhei-kuchuk) for his answer on [Global keyboard capture in C# application](https://stackoverflow.com/questions/604410/global-keyboard-capture-in-c-sharp-application) at Stack Overflow. I built the foundation of the library from the code that he provided.
* To all the people who answered on [Global mouse event handler](https://stackoverflow.com/questions/11607133/global-mouse-event-handler) at Stack Overflow. I reused some of the codes to make the Global Mouse Hook.
* Finally, to [Rasmus](https://stackoverflow.com/users/677004/rasmus) for his answer on [GET_WHEEL_DELTA_WPARAM macro in C#](https://stackoverflow.com/questions/9302891/get-wheel-delta-wparam-macro-in-c-sharp) at Stack Overflow. The code he provided was the basis for the `GetSignedHWORD`, `GetSignedLWORD`, `GetUnsignedHWORD` and `GetUnsignedLWORD` helper methods.
