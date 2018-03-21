#include "widget.h"
#include "ui_widget.h"
#include <QDebug>
#include <QProcess>
#include <qfile.h>
#include <qtextstream.h>
#include <QDir>
Widget::Widget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Widget)
{
    ui->setupUi(this);
    i = 1;
    timer = new QTimer(this);
    connect(timer, SIGNAL(timeout()), this, SLOT(showpic()));
}

Widget::~Widget()
{
    delete ui;
}

void Widget::showpic()
{
    pixmap.load(pic_name_list[i]);

//    widget.setWindowFlags(Qt::Window);
//    widget.showFullScreen();

//    wight = widget.width();
//    height = widget.height();
//    pixmap = pixmap.scaled(wight,height,Qt::IgnoreAspectRatio);
    wight  = ui->lable_showpic->width();
    height = ui->lable_showpic->height();
    pixmap = pixmap.scaled(wight,height,Qt::IgnoreAspectRatio);
    ui->lable_showpic->setPixmap(pixmap);
    ui->lable_showpic->setScaledContents(true);
    ui->lable_showpic->show();

    i++;
}

void Widget::on_start_clicked()
{
    MountUsb();
    timer->start(1000);
}

void Widget::AddPic(QString dir)
{
    //遍历所有目录和文件
    QDirIterator it(dir,QDir::Files|QDir::Dirs|QDir::NoDotAndDotDot);
    while(it.hasNext())
    {
        //读取
        QString name = it.next();
        QFileInfo info(name);
        //判断是目录
        if (info.isDir())
        {
            //递归
           this->AddPic(name);
        }
        else
        {
           if (info.suffix() == "jpg" || info.suffix() == "bmp" || info.suffix() == "png")
           {
             this->pic_name_list.append(info.filePath());//符合添加
           }
       }
    }
}

void Widget::MountUsb()
{
    program_1 = "fdisk";
    arguments << "-l";
    QProcess *cmdProcess = new QProcess();
    cmdProcess->start(program_1,arguments);
    cmdProcess->waitForStarted();
    cmdProcess->waitForReadyRead();
    cmdProcess->waitForFinished();
    procOutput=cmdProcess->readAll();


    QStringList strl = QString(procOutput.data()).split('\n');
    QStringList str = strl[strl.count() - 2].split(' ');
    usb_path = str[0];
    qDebug() << usb_path;


    program_2 = "mount";
    arguments_2 << usb_path << "/mnt/usb_ld";
    QProcess *cmdProcess_2 = new QProcess();
    cmdProcess_2->start(program_2,arguments_2);
    cmdProcess_2->waitForStarted();
    cmdProcess_2->waitForReadyRead();
    cmdProcess_2->waitForFinished();


    QString dir("/mnt/usb_ld");
    AddPic(dir);

//    program_1 = "ls";
//    arguments << "/home/";
//    QProcess *cmdProcess = new QProcess();
//    cmdProcess->start(program_1,arguments);
//    cmdProcess->waitForStarted();
//    cmdProcess->waitForReadyRead();
//    cmdProcess->waitForFinished();
//    procOutput=cmdProcess->readAll();
//    qDebug() << procOutput.data() << "\n";
}

//void Widget::on_open_clicked()
//{
////    int h = 0;
////    QStringList list = QFileDialog::getOpenFileNames(this,tr("add pic"),"/","*.png *.jpg");
////    for(it = list.begin();it < list.end();it++)
////    {
////        h++;
////        pic_name_list[h] = *it;
////    }

//}

void Widget::on_stop_clicked()
{
    timer->stop();
}
