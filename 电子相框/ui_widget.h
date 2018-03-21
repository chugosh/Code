/********************************************************************************
** Form generated from reading ui file 'widget.ui'
**
** Created: Sun May 21 18:35:32 2017
**      by: Qt User Interface Compiler version 4.5.0
**
** WARNING! All changes made in this file will be lost when recompiling ui file!
********************************************************************************/

#ifndef UI_WIDGET_H
#define UI_WIDGET_H

#include <QtCore/QVariant>
#include <QtGui/QAction>
#include <QtGui/QApplication>
#include <QtGui/QButtonGroup>
#include <QtGui/QHeaderView>
#include <QtGui/QLabel>
#include <QtGui/QPushButton>
#include <QtGui/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Widget
{
public:
    QLabel *lable_showpic;
    QPushButton *start;
    QPushButton *stop;

    void setupUi(QWidget *Widget)
    {
        if (Widget->objectName().isEmpty())
            Widget->setObjectName(QString::fromUtf8("Widget"));
        Widget->resize(800, 500);
        lable_showpic = new QLabel(Widget);
        lable_showpic->setObjectName(QString::fromUtf8("lable_showpic"));
        lable_showpic->setGeometry(QRect(0, 0, 800, 500));
        start = new QPushButton(Widget);
        start->setObjectName(QString::fromUtf8("start"));
        start->setGeometry(QRect(10, 40, 61, 21));
        stop = new QPushButton(Widget);
        stop->setObjectName(QString::fromUtf8("stop"));
        stop->setGeometry(QRect(10, 70, 61, 21));

        retranslateUi(Widget);

        QMetaObject::connectSlotsByName(Widget);
    } // setupUi

    void retranslateUi(QWidget *Widget)
    {
        Widget->setWindowTitle(QApplication::translate("Widget", "Widget", 0, QApplication::UnicodeUTF8));
        lable_showpic->setText(QString());
        start->setText(QApplication::translate("Widget", "start", 0, QApplication::UnicodeUTF8));
        stop->setText(QApplication::translate("Widget", "stop", 0, QApplication::UnicodeUTF8));
        Q_UNUSED(Widget);
    } // retranslateUi

};

namespace Ui {
    class Widget: public Ui_Widget {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_WIDGET_H
