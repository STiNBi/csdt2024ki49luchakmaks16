#include <Wire.h>
#include <NewPing.h>

const int trig = 2;
const int echo = 3;
int buzzer = A0;
int ledPin = 13;

int duration = 0;
int distance = 0;
int motionDetected = 0;

void setup()
{
    Serial.begin(9600);  // Ініціалізуємо Serial Monitor
    pinMode(trig, OUTPUT);
    pinMode(echo, INPUT);
    pinMode(buzzer, OUTPUT);
    pinMode(ledPin, OUTPUT);
}

void loop()
{
    digitalWrite(trig, HIGH);
    delayMicroseconds(1000);
    digitalWrite(trig, LOW);
    duration = pulseIn(echo, HIGH);
    distance = (duration / 2) / 29.1;
    
    Serial.print("<movemant>");
    Serial.print(distance);
    Serial.println("</movemant>");

    delay(500);

    if (distance <= 10) {
        motionDetected = 1;
    } else {
        motionDetected = 0;
    }

    if (motionDetected == 1) {
        digitalWrite(ledPin, HIGH);
        for (int i = 0; i < 80; i++) {
            digitalWrite(buzzer, HIGH);
            delay(1);
            digitalWrite(buzzer, LOW);
            delay(1);
        }
        delay(10);
        for (int j = 0; j < 100; j++) {
            digitalWrite(buzzer, HIGH);
            delay(1);
            digitalWrite(buzzer, LOW);
            delay(1);
        }
        delay(5);
        digitalWrite(ledPin, LOW);
    }
}
