#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QTimer>
#include <QtGui>
#include "QToolButton"
#include "QLabel"
#include "QTimer"
#include "QString"
#include "QPixmap"
#include "QPalette"
#include "QMatrix"
#include "QImage"
#include "QBrush"
#include "QFileDialog"
#include "QMessageBox"
#include "QDebug"
namespace Ui {
class Widget;
}

class Widget : public QWidget
{
    Q_OBJECT
    
public:
    explicit Widget(QWidget *parent = 0);
    ~Widget();
    
private:

    Ui::Widget *ui;
    QTimer *timer; //当按下播放按钮时启动定时器

    int i,j,k;
    QStringList pic_name_list;//图片名称list
    qreal wight,height;//double
    QString pic_name;
    QString usb_path;
    QPixmap pixmap;           //显示图片
    QStringList::Iterator it;//迭代

    QString program_1;
    QString program_2;
    QStringList arguments;
    QStringList arguments_2;
    QByteArray procOutput;

public:
    void AddPic(QString dir);
    void MountUsb();
public slots:
    void showpic();
private slots:
    void on_start_clicked();//开始

    void on_stop_clicked();
};

#endif // WIDGET_H
