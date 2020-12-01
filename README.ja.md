# VgoSpringBone

VgoSpringBone �� Unity �Ŏg�p����œK�����ꂽ�X�v�����O �{�[���ł��B

___
## ����

- �������x�Ə������ׂ��œK������Ă��܂��B
- Gizmo�ŃX�v�����O �{�[���ƃR���C�_�[�̓��������o�I�Ƀ`�F�b�N���邱�Ƃ��ł��܂��B

## �R���|�[�l���g

- VgoSpringBoneGroup
- VgoSpringBoneColliderGroup

## �ݒ�

�ݒ���@�̐����ł��B

### 1. Spring Bone Manager

�C�ӂ� GameObject ���������܂��B  
�i�����ł�`SpringBoneManager`�Ƃ������O�̃Q�[���I�u�W�F�N�g�Ƃ��܂��B�j

SpringBoneManager �� `Vgo Spring Bone Group` �R���|�[�l���g��V�����t�^���܂��B  
�i�����̃O���[�v���g�p����ꍇ�ɂ͂���ɃR���|�[�l���g�t�^���Ă��������B�j

### 2. Spring Bone

#### Vgo Spring Bone Group

|No|����|����|�K�{|�I��l|����l|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Comment|���̃O���[�v�����[�U�[���ʂ��邽�߂̖��O�ł��B|�C��|||
|2|Drag Force|�R�͂ł��B�l���傫���قǗh��ɂ����Ȃ�܂��B|�K�{|[0.0 - 1.0]|0.2|
|3|Stiffness Force|�����ł��B�l���傫���قǌ��̏�Ԃɖ߂�₷���Ȃ�܂��B|�K�{|[0.0 - 4.0]|1.0|
|4|Gravity Direction|�d�͂̌����ł��B|�K�{||x: 0.0, y: -1.0, z: 0.0|
|5|Gravity Power|�d�͂̑傫���ł��B|�K�{|[0.0 - 2.0]|0.2|
|6|Root Bones|�h�炵�����{�[���̍����̃Q�[���I�u�W�F�N�g���w�肵�܂��B<br>���[�g�{�[���𕡐��w�肷�邱�ƂŐݒ�𓯂��O���[�v�Ƃ��Ă܂Ƃ߂邱�Ƃ��ł��܂��B|�K�{|||
|7|Hit Radius|�e�{�[���̓����蔻��ƂȂ鋅�̔��a�ł��B|�K�{|[0.0 - 0.5]|0.02|
|8|Collider Groups|���̃X�v�����O �{�[�� �O���[�v�����m����R���C�_�[�̃O���[�v�ł��B|�C��|||
|9|Draw Gizmo|Editor �� Gizmo ��`�悷��ۂ� Spring Bone ��`�悵�܂��B|�K�{|true / false|false|
|10|Gizmo Color|Spring Bone �̕`��F�ł��B|�K�{||yellow|

�K�v������� SpringBoneCollider �̐ݒ��ǉ��ōs���܂��B

### 3. Spring Bone Collider

�R���C�_�[��ݒu�������ӏ��� GameObject ��I�����܂��B  
�i���ł���Γ��ȂǁB�j

GameObject �� `Vgo Spring Bone Collider Group` �R���|�[�l���g��V�����t�^���܂��B

#### Vgo Spring Bone Collider Group

|No|����|����|�K�{|�I��l|����l|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Colliders|�X�v�����O �{�[�� �R���C�_�[��ݒ肵�܂��B|�K�{|||
|2|Gizmo Color|�X�v�����O �{�[�� �R���C�_�[ �̕`��F�ł��B|�K�{||magenta|

#### Vgo Spring Bone Collider

|No|����|����|�K�{|�I��l|����l|
|:---:|:---|:---|:---:|:---:|:---:|
|1|Collider Type|�R���C�_�[�̎�ނł��B|�K�{|Sphere|Sphere|
|2|Offset|GameObject ����̑��Έʒu�ł��B|�K�{||x: 0.0, y: 0.0, z: 0.0|
|3|Radius|���̔��a�ł��B|�K�{|[0.0 - 1.0]|0.0|

___
�ŏI�X�V���F2020�N12��1��  
�ҏW�ҁF�\�Z�邨���������

*Copyright (C) 2020 Izayoi Jiichan. All Rights Reserved.*
