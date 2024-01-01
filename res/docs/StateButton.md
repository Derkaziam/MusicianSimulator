# StateButton Class

A basic state button, when used alongside a handler it can be used to handle systems such as menus.

### Publically-Exposed Data/Methods
- Ping
    - A way to check if the button has been clicked, resets to false every frame.
- BeenClicked
    - The current state of the button, on = true, off = false. Says the same until pinged to change.  
- Update()
    - Handles all logic for the button.
- Draw()
    - Renders the button to the screen.
