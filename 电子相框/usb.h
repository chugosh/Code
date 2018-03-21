#ifndef USB_H
#define USB_H

#include <QObject>
#include <QString>
#include <QBasicTimer>
#include <QTimerEvent>
#include <QRegExp>
#include <QProcess>
#include <QByteArray>
#include <QDir>

class USB : public QObject
{
    Q_OBJECT

public:
    QStringList nameList;

}




#endif // USB_H
