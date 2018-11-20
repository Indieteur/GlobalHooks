# Global Hooks
Allows you to **listen for Global Keyboard and Mouse events** so even if your **application is inactive**, it'll still **capture Mouse and Keyboard input**. This can be used to make global keyboard shortcuts for example.

# Compatibility
The solution itself was created using **Visual Studio 2017** so you'll probably only be able to open it through that however, if you are using the **prebuilt library (.dll)** or the [**Nuget package**](https://www.nuget.org/packages/Indieteur.GlobalHooks/). It's target framework is **.Net Framework 4.6.1**.

# How to Use
There is a **Demo project included** which shows you how to use the library. The events, enumerations, types, properties and whatnot also have **summarized descriptions** so you can use the **object browser** to learn more about them. 

# License
This library is licensed under [CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication](https://creativecommons.org/publicdomain/zero/1.0/). Also, no need to credit me by the way but if you do, please credit me as Indieteur and if you can, please include my [website](https://indieteur.com) as well. (e.g. `GlobalHooks by Indieteur - https://indieteur.com`)

# How to Help
Currently, I'm **working full time making open source software** and free assets and **using my savings to pay my bills** so I hope you help me with that by either:


* [![ko-fi](https://www.ko-fi.com/img/donate_sm.png)](https://ko-fi.com/Y8Y8M5JV) if you want **make a one time donation**.

* [![Patreon](https://c5.patreon.com/external/logo/become_a_patron_button.png)](https://www.patreon.com/indieteur) if you want to **donate evey month**.


# Credits
* [Siarhei Kuchuk](https://stackoverflow.com/users/212746/siarhei-kuchuk) for his answer on [Global keyboard capture in C# application](https://stackoverflow.com/questions/604410/global-keyboard-capture-in-c-sharp-application) at **Stack Overflow**. I built the **foundation of the library** from the code that he provided.
* To all the people who answered on [Global mouse event handler](https://stackoverflow.com/questions/11607133/global-mouse-event-handler) at **Stack Overflow**. I reused some of the codes to make the Global Mouse Hook.
* Finally, to [Rasmus](https://stackoverflow.com/users/677004/rasmus) for his answer on [GET_WHEEL_DELTA_WPARAM macro in C#](https://stackoverflow.com/questions/9302891/get-wheel-delta-wparam-macro-in-c-sharp) at **Stack Overflow**. The code he provided was the basis for the `GetSignedHWORD`, `GetSignedLWORD`, `GetUnsignedHWORD` and `GetUnsignedLWORD` helper methods.
