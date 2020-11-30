# VgoSpringBone

VgoSpringBone is a processing-optimized Spring Bone used in Unity.

___
## Features

- The processing speed and processing load are optimized.
- You can visually check the movement of the spring bone and collider with Gizmo.

## Components

- VgoSpringBoneGroup
- VgoSpringBoneColliderGroup

## Settings

This section explains how to set spring.

### 1. Spring Bone Manager

Prepare any game object.
(Here we name the GameObject `SpringBoneManager`.)

Attach a new `Vgo Spring Bone Group` component to SpringBoneManager.  
(If you use multiple groups, attach more components.)

### 2. Spring Bone

#### Vgo Spring Bone Group

|No|item|description|required|select value|default value|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Comment|A name to identify this group as a user.|option|||
|2|Drag Force|The larger the value, the less likely it is to swing.|required|[0.0 - 1.0]|0.2|
|3|Stiffness Force|The higher the value, the easier it is to return to the original state.|required|[0.0 - 4.0]|1.0|
|4|Gravity Direction|The direction of gravity.|required||x: 0.0, y: -1.0, z: 0.0|
|5|Gravity Power|The magnitude of gravity.|required|[0.0 - 2.0]|0.2|
|6|Root Bones|Specify the game object at the base of the bone you want to swing.<br>By specifying multiple root bones, the settings can be grouped together.|required|||
|7|Hit Radius|The radius of the sphere that determines the collision of each bone.|required|[0.0 - 0.5]|0.02|
|8|Collider Groups|This is a group of colliders detected by this spring bone group.|option|||
|9|Draw Gizmo|The Editor draws the Spring Bone when it draws the Gizmo.|required|true / false|false|
|10|Gizmo Color|The drawing color of Spring Bone.|required||yellow|

If necessary, make additional settings for SpringBoneCollider.

### 3. Spring Bone Collider

Select the GameObject where you want to place the collider.  
(For hair, head, etc.)

Attach a new `Vgo Spring Bone Collider Group` component to the GameObject.

#### Vgo Spring Bone Collider Group

|No|item|description|required|select value|default value|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Colliders|Set the spring bone collider.|required|||
|2|Gizmo Color|The drawing color of the spring bone collider.|required||magenta|

#### Vgo Spring Bone Collider

|No|item|description|required|select value|default value|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Collider Type|The type of collider.|required|Sphere|Sphere|
|2|Offset|Relative to the GameObject.|required||x: 0.0, y: 0.0, z: 0.0|
|3|Radius|The radius of the sphere.|required|[0.0 - 1.0]|0.0|

___
Last updated: 1 December, 2020  
Editor: Izayoi Jiichan

*Copyright (C) 2020 Izayoi Jiichan. All Rights Reserved.*
