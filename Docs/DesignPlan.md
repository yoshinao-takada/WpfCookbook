# Design Plan of `WpfCookbook`
## Visual Design Point to Take Care
* Fixed aspect ratio, same as VGA (640 x 480) but window size is variable.
* Line height is limited to three types (20 lines, 10 lines, 5 lines per a window)
* Font sizes are 70 % of line heights.
* Every UI components have three color configurations, 1) for normal state, 2) for
selected state, and 3) for disabled state.
* Images and text resources are stored in a pack.
* Users controls can be run in small test applications
