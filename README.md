# Mirror image 
Algorithm to which accepts an image as input and results its equivalent mirrored image.

## Description
Provide an interface method that can be consumed by a potential Media Player which plays videos on "mirrored mode", actual images must be seen like being viewed on mirror. Example: 

|   Original Frame| Mirror Frame  |
| ------------ | ------------ |
|  <img src="https://github.com/slipmp/mirror-image/blob/master/MirrorImage.Core.Tests/Frame-Examples/All-Resolutions/1-SD-720-480.jpg?raw=true" height="200"> | <img src="https://github.com/slipmp/mirror-image/blob/master/MirrorImage.Core.Tests/Frame-Examples/All-Resolutions/1-SD-720-480-Mirror.jpg?raw=true" height="200">  |

Refer to table below regarding current standard movie resolutions:

| Name  | Resolution   |
| ------------ | ------------ |
| Standard Definition (SD)  | 720 × 480  |
| HD  | 1280 × 720  |
| Full HD  |  1920 × 1080 |
| Ultra HD  |  3840 × 2160 |
| 4K  |  4096×2160 |

## Frames per Second
The frame rates for TV and films are standardized by The Society of Motion Picture and Television Editors, also known as SMPTE.
Most of movies are recorded at **24 FPS**, with exception of few such as The Hobbit being shot at **48 FPS**, negligent evidence on cinema movies recorded using **60 FPS**.

## Acceptance Criteria
Algorithm should be able to process frames within all resolutions provided above on average of **40 milliseconds** => 
24 frames * 40 milliseconds = 960 milliseconds total, under 1 second (1000 milleseconds).


## References
- https://www.borrowlenses.com/blog/intro-to-video-frame-rates-and-frames-per-second-shooting-speeds/
- https://pocketnow.com/uhd-video-looks-better
- http://aframe.com/blog/2013/07/a-beginners-guide-to-frame-rates/
- https://www.studiobinder.com/blog/video-frame-rate/
- https://gizmodo.com/the-hobbit-an-unexpected-masterclass-in-why-48-fps-fai-5969817

## Solution Details
Application is composed by three Projects:
1. MirrorImage.App => Windows forms app, initially created to provide a visual cue during development
2. MirrorImage.Core => Major logic implemented
3. MirrorImage.Core.Tests => Unit tests project. Results:
<img src="https://github.com/slipmp/mirror-image/blob/master/Mirror-Image-Tests-Passing.png?raw=true">


Main method implemented is located at **MirrorImage.Core.FrameMirrorService.MirrorImage(Bitmap imgInput)**

### Version 1 - Removed
.NET Framework provides a rotate flip out of the box:
```csharp
imageOutput.RotateFlip(RotateFlipType.RotateNoneFlipX);
```
It does not have the best performance, for instance such algorithm would not work for 4K Movies using 60 FPS. Ideally an algorithm should be implemented for such high performance requirements. Also computer configuration has impact on its performance. Provided more time I would have implemented several enhancements, including development of a proper algorithm and more tests.

The "Mirror Movie Player" can have a buffer implementation, hence processing these frames before hand and enhancing user experience.

### Version 2 - Using pointers to enhance performance
Now application is using pointers and unmanaged code. Quite a complicated logic, but definitely faster than solution provided by the Framework.

