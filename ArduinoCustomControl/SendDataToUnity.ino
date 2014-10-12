const int buttonLeft=5;
const int buttonRight=6;
const int buttonDown=7;
const int buttonUp=8;
void setup() 
{
  // put your setup code here, to run once:
  
  Serial.begin(9600);
  pinMode(buttonLeft,INPUT);
  digitalWrite(buttonLeft,LOW);
  digitalWrite(buttonRight,LOW);
  digitalWrite(buttonUp,LOW);
  digitalWrite(buttonDown,LOW);
}

void loop() 
{
  if(digitalRead(buttonLeft)==HIGH)
  {
    Serial.write(1);
    Serial.flush();
    delay(20);
  }
  if(digitalRead(buttonRight)==HIGH)
  {
    Serial.write(2);
    Serial.flush();
    delay(20);
  }
   if(digitalRead(buttonUp)==HIGH)
  {
    Serial.write(3);
    Serial.flush();
    delay(20);
  }
   if(digitalRead(buttonDown)==HIGH)
  {
    Serial.write(4);
    Serial.flush();
    delay(20);
  }
}

