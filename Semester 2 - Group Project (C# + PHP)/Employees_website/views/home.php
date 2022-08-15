<?php require 'authentication/authentication.php'; ?>
<?php if (isset($_GET['message'])) : ?>
     <?php if ($_GET['message'] == 'success') : ?>
          <div class="success">
               <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
               You have checked-out successfully.
          </div>
     <?php elseif ($_GET['message'] == 'sick') : ?>
          <div class="success">
               <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
               You have called in sick successfully.
          </div>
     <?php else : ?>
          <div class="alert">
               <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
               <?php echo  $_GET['message']; ?>
          </div>
     <?php endif ?>
<?php endif ?>
<div id="page_layout">
     <div id="table_container">
          <div class="row">
               <table float="left" class="col-xs-7 table-bordered table-striped table-condensed table-fixed">
                    <thead>
                         <tr>
                              <th class="col">Work shift ID</th>
                              <th class="col">Period</th>
                              <th class="col">Date</th>
                         </tr>
                    </thead>
                    <tbody>
                         <?php
                         $id = (int)$_SESSION['logged'];
                         $db = new ShiftMediator();
                         $shifts = $db->GetAllShiftsForEmployee($id);
                         global $date, $month;
                         if ($shifts != NULL) :
                              $i = 0;
                              foreach ($shifts as $row) { ?>
                                   <tr>
                                        <td class="col"><?php echo $row->getId(); ?></td>
                                        <td class="col"><?php echo $row->getType(); ?></td>
                                        <td class="col"><?php $month[$i] = $row->getDate();
                                                            echo date('M/d/Y', strtotime($month[$i]));  ?></td>
                                   </tr>
                         <?php
                                   $i++;
                              }
                              //$month=date('d',strtotime($month[0]));
                              $exp = date('m-Y', strtotime($month[0]));
                              $exp1 = explode('-', $exp);

                              $month = $exp1[0];
                              $year = $exp1[1];


                         endif;
                         if (isset($_GET['month'])) {
                              $newdate = '01-' . $_GET['month'] . '-' . $_GET['year'];
                              $date = new DateTime($newdate);
                              if ($_GET['move'] == 'P') {
                                   $date->modify('-0 month');
                              } else {
                                   $date->modify('+0 month'); // or '-90 day' 

                              }

                              $month = $date->format('m');
                              $year = $date->format('Y');
                         }



                         ?>

                    </tbody>
               </table>
          </div>
          <div class="pagination">

               <a class="btn" href="index.php?page=home">Reset</a>
               <a class="btn" href="index.php?page=home&month=<?php if (isset($_GET['move'])) {
                                                                      if ($_GET['month'] == 1) {
                                                                           echo $month = 12;
                                                                           $year = $year - 1;
                                                                      } else {
                                                                           echo $month - 1;
                                                                      }
                                                                 } else {
                                                                      echo $month - 1;
                                                                 } ?>&year=<?= $year ?>&move=P">Previous Month</a>
               <a class="btn" href="index.php?page=home&month=<?php if (isset($_GET['move'])) {
                                                                      $month = $month + 1;
                                                                      if ($_GET['month'] == 12) {
                                                                           $month = 1;
                                                                           $year = $year + 1;
                                                                      }

                                                                      if ($_GET['month'] == 0) {
                                                                           $month = 12;
                                                                           $year = $year + 1;
                                                                      }
                                                                      if ($_GET['month'] == 1) {
                                                                           $month = 2;
                                                                           $year = $_GET['year'];
                                                                      }

                                                                      echo $month;
                                                                 } else {
                                                                      echo $month + 1;
                                                                 } ?>&year=<?= $year ?>&move=N">Next Month</a>

          </div>
     </div>
     <?php if (!isset($_SESSION['zeroHours'])) : ?>
          <div id="list_container">
               <div float="left" class="wrapper">
                    <div class="checkbox_container">
                         <div class="title">Unavailable for work shifts</div>
                         <form action="handlers/availabilityHandler.php" method="post">
                              <?php
                              $id = (int)$_SESSION['logged'];
                              $db = new UserMediator();
                              $days = $db->GetAvailableDays($id);
                              $nightshift = $db->GetNightshiftAvailability($id);
                              if ($days != null) : ?>

                                   <div class='checkbox_wrap'>
                                        Monday
                                        <input type='checkbox' class='checkbox' name='days[]' value='M' <?php if (strpos($days, 'M') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>
                                   <div class="checkbox_wrap">
                                        Tuesday
                                        <input type="checkbox" class="checkbox" name="days[]" value="T" <?php if (strpos($days, 'T') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>
                                   <div class="checkbox_wrap">
                                        Wednesday
                                        <input type="checkbox" class="checkbox" name="days[]" value="W" <?php if (strpos($days, 'W') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>
                                   <div class="checkbox_wrap">
                                        Thursday
                                        <input type="checkbox" class="checkbox" name="days[]" value="Th" <?php if (strpos($days, 'Th') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>
                                   <div class="checkbox_wrap">
                                        Friday
                                        <input type="checkbox" class="checkbox" name="days[]" value="F" <?php if (strpos($days, 'F') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>
                                   <div class="checkbox_wrap">
                                        Saturday
                                        <input type="checkbox" class="checkbox" name="days[]" value="S" <?php if (strpos($days, 'S') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>
                                   <div class="checkbox_wrap">
                                        Sunday
                                        <input type="checkbox" class="checkbox" name="days[]" value="U" <?php if (strpos($days, 'U') !== false) {
                                                                                                              echo 'checked';
                                                                                                         } ?>>
                                   </div>

                                   <hr>
                                   <div class="checkbox_wrap">
                                        At night shifts
                                        <input type="checkbox" class="checkbox" name="nightShift" value="True" <?php if ($nightshift == 'Unavailable') {
                                                                                                                        echo 'checked';
                                                                                                                   } ?>>
                                   </div>
                              <?php endif ?>
                              <input id="btnSave" type="submit" value="Save">
                         </form>
                    </div>
               </div>
          </div>
     <?php endif; ?>
</div>