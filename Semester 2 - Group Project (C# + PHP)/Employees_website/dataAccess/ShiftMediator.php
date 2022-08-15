<?php
require dirname(__FILE__) . '/../autoload/init.php'; //from Stanislav
class ShiftMediator extends DatabaseMediator
{

    public function GetAllShiftsForEmployee($id)
    {
        $paginate = false;
        global $sth;
        if (isset($_GET['month']) && isset($_GET['year'])) {
            $month = $_GET['month'];
            $year = $_GET['year'];

            $month = sprintf("%02d", $month);

            $sql = "SELECT ID, Type, Date FROM workshift WHERE employee_id = :id and Date like '$month/%'";
            $sth = $this->conn->prepare($sql);

            $sth->execute([
                ':id' => $id
            ]);
            $paginate = true;

            global $shifts;
            if ($sth->rowCount() > 0) {

                $shifts = array();
                $result = $sth->fetchAll();
                foreach ($result as $row) {

                    $shifts[] = new WorkShift($row['ID'], $row['Type'], $row['Date']);
                }
            }
            if ($sth->rowCount() > 0) {
                function date_compare($a, $b)
                {
                    return strcmp($a->getDate(), $b->getDate());
                }

                usort($shifts, "date_compare");
            }
            return $shifts;
        } else {

            $sql = 'SELECT ID, Type, Date FROM workshift WHERE employee_id = :id';
            $sth = $this->conn->prepare($sql);
            $sth->execute([
                ':id' => $id
            ]);
        }

        if ($sth->rowCount() >= 1) {

            $shifts = array();
            $result = $sth->fetchAll();

            $firstDayOfMonth = date('M 01 Y');
            $first = strval($firstDayOfMonth);
            $first1 =  strtotime($first);

            $lastDayOfMonth =  date('M t Y');

            $last = strval($lastDayOfMonth);
            $last1 = strtotime($last);

            foreach ($result as $row) {
                $d = strval($row['Date']);

                $shiftDate  = strtotime($d);
                if ($first1 <= $shiftDate && $shiftDate <= $last1) {
                    $shifts[] = new WorkShift($row['ID'], $row['Type'], $row['Date']);
                }
            }

            //Sorting
            function date_compare($a, $b)
            {
                return strcmp($a->getDate(), $b->getDate());
            }
            usort($shifts, "date_compare");

            return $shifts;
        } else {
            return null;
        }
    }

    public function CancelShift()
    {
        $id = (int)$_SESSION['logged'];
        $day = date('m/d/Y');

        $sql = 'UPDATE workshift SET Cancelled = :cancelled WHERE employee_id = :id AND Date = :date;';
        $sth = $this->conn->prepare($sql);
        $sth->execute([
            ':cancelled' => 'True',
            ':id' => $id,
            ':date' => $day
        ]);
    }
}
