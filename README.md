# Array-fault-tolerant-system

这个项目是为我们的[基于多斜率码链阵列纠删码](http://www.joca.cn/CN/abstract/abstract20400.shtml)编写的验证Demo。

它使用了一种新的基于码链构造的阵列纠删码。该阵列纠删码使用不同斜率码链组织数据元素和校验元素之间的关系，从而可以达到理论上不受限制的容错能力；同时在构造时避开了类似素数约束的强约束条件，易于实用和扩展。
仿真试验结果表明，相对于RS（Reed-Solomon）码，基于多斜率码链阵列纠删码在运算效率上的提升超过2个数量级。

而本项目可以在本地单个计算机中模拟分布式存储的情况，将不同文件夹作为不同的存储节点，实现存储及灾后恢复的功能。

## 特点

* 理论上不受限制的容错能力
* 运算效率上较RS码的提升超过2个数量级
* 效率能随着条块尺寸的增加而提高（固定容错能力）

## 使用说明

1. 启动程序后将显示根目录选择及文件夹名设置界面，选择合法的路径并输入任意合法的文件夹名称后，点击确认可保存并进入初始化界面。

!["首页"](/Screenshots/FirstWindow.png)

2. 初始化界面

!["初始化界面"](/Screenshots/InitWindow.png)

    a. 请先选择容错数量和阵列行数，确认后点击右上角的确认按钮
    b. 之后在左侧文件夹列表中根据上方提示选择足够数量的数据盘，可点击“全选”、“反选”或“自动选择”按钮执行相应操作，确认后点击中间的确认按钮
    c. 确认数据盘后，在右侧剩余文件夹列表中选择冗余盘，同样可点击“全选” 或“反选”按钮执行相应操作，确认后点击右下角确认按钮，即可完成系统的初始化，并关闭初始化界面
    d. 可随时点击重置按钮重新配置系统
3. 完成初始化后，将显示工作界面

!["工作界面"](/Screenshots/WorkingWindow.png)

    a. 工作界面最上方将显示所有设备的状态，设备正常工作时，磁盘图标为黑色，磁盘丢失时将显示为红色，图标下方为磁盘名，括号中为磁盘路径，名称下方为磁盘状态及该磁盘为数据盘或冗余盘
    b. 点击“选择文件”按钮可选择文件添加至存储队列中，点击“移除文件”按钮可将队列中的文件移除
    c. 点击"存入系统"按钮可将队列中的文件存储至系统中，完成后已存储文件将显示在右侧列表中
    d. 在右侧列表中选择文件后，点击“输出文件”按钮可将系统中存储的文件导出至其他位置，点击“从系统中移除”按钮可将文件从系统中移除
    e. 丢失容错数量内的文件夹时，可随时点击中间的恢复按钮，程序将自动恢复系统
    
## 细节

!["结构"](/Screenshots/Structure.png)

对于存入系统的每个文件，在系统中以分块形式存储，而每个文件的数据块分为数据分块和校验分块。分块的数量由分块阵列的行数和最大容错数决定。具体文件存储方式如下图（以分块行数2，最大容错数2为例）：

!["文件结构"](/Screenshots/FileStructure.png)

用户在设定分块行数和最大容错数后，会自动生成足够数量的空文件夹作为存储节点，用户在列表中选择足够的节点，分别作为数据节点和校验节点，用于存储数据分块和校验分块。

当用户将一个文件存入系统时，会将该文件平均分割（如果无法均分，则在文件末尾添加空字节补齐），同时使用分割后的数据分块计算生成校验分块，之后存入各分块对应的节点。

当系统中有节点丢失，但丢失节点数未超过最大容错数时，系统进入“警告”状态。这种状态下，用户可随时恢复系统，将丢失的所有分块恢复。同时也依然可以向系统中继续存入文件或是从系统中提取文件。