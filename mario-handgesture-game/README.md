# 手势控制超级马里奥游戏

通过手势玩经典游戏，如超级马里奥兄弟！无需键盘或鼠标输入。这是一种有趣且未来感十足的方式，重温旧游戏。

使用 **Python 3.6** 开发，需要Python 3.6及以上版本以及必要的软件包、Intel RealSense 摄像头。

## 超级马里奥兄弟

屏幕水平分为三等份。检测到的动作：
- 左侧部分张开手掌 -> 向左跳跃
- 左侧部分握拳 -> 向左奔跑
- 中间部分张开手掌 -> 跳跃
- 中间部分握拳 -> 不做任何动作
- 右侧部分张开手掌 -> 向右跳跃
- 右侧部分握拳 -> 向右奔跑

## 安装软件包

```bash
pip install -r requirements.txt -i https://pypi.tuna.tsinghua.edu.cn/simple
```

## 运行游戏

```bash
python mario.py
```

## Python软件包

- cv2
- tensorflow
- numpy
- gym
- gym_super_mario_bros
- pygame
- opencv
- pyrealsense2