<?php

require dirname(__FILE__) . '/../autoload/init.php';

class AttendanceMediator extends DatabaseMediator
{
    public function CheckIn()
    {
        $id = (int)$_SESSION['logged'];
        $day = date('m/d/Y');
        $time = date('m/d/Y H:i');

        $sql = 'INSERT INTO attendance(employee_id, check_in, date) VALUES(:employee_id, :checkIn, :date)';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':employee_id' => $id,
            ':checkIn' => $time,
            ':date' => $day
        ]);
    }

    public function CheckOut()
    {
        $id = (int)$_SESSION['logged'];
        $day = date('m/d/Y');
        $time = date('m/d/Y H:i');

        $sql = 'UPDATE attendance SET check_out = :time WHERE employee_id = :id AND date= :date';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id,
            ':date' => $day,
            ':time' => $time,
        ]);
    }

    public function CallInSick()
    {
        $id = (int)$_SESSION['logged'];
        $day = date('m/d/Y');
        $time = date('m/d/Y H:i');

        $sql = 'INSERT INTO attendance(employee_id, check_in ,check_out, date) VALUES(:employee_id,:checkIn ,:checkOut, :date)';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':employee_id' => $id,
            ':checkOut' => $time,
            ':checkIn' => $time,
            ':date' => $day
        ]);
    }

    public function CheckState(): int
    {
        $id = (int)$_SESSION['logged'];
        $day = date('m/d/Y');

        $sql = 'SELECT * FROM attendance WHERE employee_id = :id AND date= :date';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':id' => $id,
            ':date' => $day
        ]);

        if ($sth->rowCount() == 1) {
            $result = $sth->fetch();
            //Checked-in, but not checked-out
            if ($result['check_out'] == null) {
                return 1;
            }
            //Checked-out
            return -1;
        }
        //Not checked-in
        else {
            return 0;
        }
    }
}
