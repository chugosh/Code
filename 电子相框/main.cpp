#include <QtGui/QApplication>
#include "widget.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    Widget w;
    w.setWindowFlags(Qt::Window);
    w.showFullScreen();
    w.show();
    
    return a.exec();
}
