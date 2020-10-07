# EnumTools
Ongoing Enum Extensions Assembly

Allows users to iterate forward and backwards through an Enum with optional enum looping that can be controlled by a looping attribute or telling the method manually to loop regardless of the looping attribute.

Allows Random to select an element from the values, can be controlled by an Enum Field attribute Count.

Looping is an empty attribute that tells Next and Prev to loop around when the new value would otherwise be out of range.

Count is an Enum Field attribute that tells Random how many 'Copies' of the enum value to create when selecting the return element, allowing users to increase or decrease the chances of certain values being returned.
