# gcode-postprocessor
This program allows to add more things to a gcode that CURA doesn't have from 
the get-go.

### Functions
---
GCode between layers
To be added: Add a pause at a certain layer
To be added: Merge multiple gcodes

### GCODE between layers
As Cura for some reason doesn't have the ability to add commands to execute at 
every layer this post-processor allows to add it.

### Pause at layer (To be added)
---
This function allows to pause the print at any given layer. The print has to be 
resumed by the user.


The intention of this is to enable things such as:
* Add captive nuts, bolts etc.
* Change filament mid print.

### Merge multiple gcodes (To be added)
---
With this function multiple gcodes are merged with a M600 command between them. 
This way multicolor prints can be achieved with only one print-head.

Multiple considerations have to be taken into account during the design when 
using this mode.These considerations will be added when the function is finished
