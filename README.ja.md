# VgoSpringBone

VgoSpringBone は Unity で使用する最適化されたスプリング ボーンです。

___
## 特徴

- 処理速度と処理負荷が最適化されています。
- Gizmoでスプリング ボーンとコライダーの動きを視覚的にチェックすることができます。

## コンポーネント

- VgoSpringBoneGroup
- VgoSpringBoneColliderGroup

## 設定

設定方法の説明です。

### 1. Spring Bone Manager

任意の GameObject を準備します。  
（ここでは`SpringBoneManager`という名前のゲームオブジェクトとします。）

SpringBoneManager に `Vgo Spring Bone Group` コンポーネントを新しく付与します。  
（複数のグループを使用する場合にはさらにコンポーネント付与してください。）

### 2. Spring Bone

#### Vgo Spring Bone Group

|No|項目|説明|必須|選択値|既定値|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Comment|このグループをユーザー識別するための名前です。|任意|||
|2|Drag Force|抗力です。値が大きいほど揺れにくくなります。|必須|[0.0 - 1.0]|0.2|
|3|Stiffness Force|剛性です。値が大きいほど元の状態に戻りやすくなります。|必須|[0.0 - 4.0]|1.0|
|4|Gravity Direction|重力の向きです。|必須||x: 0.0, y: -1.0, z: 0.0|
|5|Gravity Power|重力の大きさです。|必須|[0.0 - 2.0]|0.2|
|6|Root Bones|揺らしたいボーンの根元のゲームオブジェクトを指定します。<br>ルートボーンを複数指定することで設定を同じグループとしてまとめることができます。|必須|||
|7|Hit Radius|各ボーンの当たり判定となる球の半径です。|必須|[0.0 - 0.5]|0.02|
|8|Collider Groups|このスプリング ボーン グループが検知するコライダーのグループです。|任意|||
|9|Draw Gizmo|Editor が Gizmo を描画する際に Spring Bone を描画します。|必須|true / false|false|
|10|Gizmo Color|Spring Bone の描画色です。|必須||yellow|

必要があれば SpringBoneCollider の設定を追加で行います。

### 3. Spring Bone Collider

コライダーを設置したい箇所の GameObject を選択します。  
（髪であれば頭など。）

GameObject に `Vgo Spring Bone Collider Group` コンポーネントを新しく付与します。

#### Vgo Spring Bone Collider Group

|No|項目|説明|必須|選択値|既定値|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Colliders|スプリング ボーン コライダーを設定します。|必須|||
|2|Gizmo Color|スプリング ボーン コライダー の描画色です。|必須||magenta|

#### Vgo Spring Bone Collider

|No|項目|説明|必須|選択値|既定値|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Collider Type|コライダーの種類です。|必須|Sphere|Sphere|
|2|Offset|GameObject からの相対位置です。|必須||x: 0.0, y: 0.0, z: 0.0|
|3|Radius|球の半径です。|必須|[0.0 - 1.0]|0.0|

___
最終更新日：2020年12月1日  
編集者：十六夜おじいちゃん

*Copyright (C) 2020 Izayoi Jiichan. All Rights Reserved.*
