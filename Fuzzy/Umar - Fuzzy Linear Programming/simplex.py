# import heapq


# '''
#    Return a rectangular identity matrix with the specified diagonal entiries, possibly
#    starting in the middle.
# '''
# def identity(numRows, numCols, val=1, rowStart=0):
#    return [[(val if i == j else 0) for j in range(numCols)]
#                for i in range(rowStart, numRows)]


# '''
#    standardForm: [float], [[float]], [float], [[float]], [float], [[float]], [float] -> [float], [[float]], [float]
#    Convert a linear program in general form to the standard form for the
#    simplex algorithm.  The inputs are assumed to have the correct dimensions: cost
#    is a length n list, greaterThans is an n-by-m matrix, gtThreshold is a vector
#    of length m, with the same pattern holding for the remaining inputs. No
#    dimension errors are caught, and we assume there are no unrestricted variables.
# '''
# def standardForm(cost, greaterThans=[], gtThreshold=[], lessThans=[], ltThreshold=[],
#                 equalities=[], eqThreshold=[], maximization=True):
#    newVars = 0
#    numRows = 0
#    if gtThreshold != []:
#       newVars += len(gtThreshold)
#       numRows += len(gtThreshold)
#    if ltThreshold != []:
#       newVars += len(ltThreshold)
#       numRows += len(ltThreshold)
#    if eqThreshold != []:
#       numRows += len(eqThreshold)

#    if not maximization:
#       cost = [-x for x in cost]

#    if newVars == 0:
#       return cost, equalities, eqThreshold

#    newCost = list(cost) + [0] * newVars

#    constraints = []
#    threshold = []

#    oldConstraints = [(greaterThans, gtThreshold, -1), (lessThans, ltThreshold, 1),
#                      (equalities, eqThreshold, 0)]

#    offset = 0
#    for constraintList, oldThreshold, coefficient in oldConstraints:
#       constraints += [c + r for c, r in zip(constraintList,
#          identity(numRows, newVars, coefficient, offset))]

#       threshold += oldThreshold
#       offset += len(oldThreshold)

#    return newCost, constraints, threshold


# def dot(a,b):
#    return sum(x*y for x,y in zip(a,b))

# def column(A, j):
#    return [row[j] for row in A]

# def transpose(A):
#    return [column(A, j) for j in range(len(A[0]))]

# def isPivotCol(col):
#    return (len([c for c in col if c == 0]) == len(col) - 1) and sum(col) == 1

# def variableValueForPivotColumn(tableau, column):
#    pivotRow = [i for (i, x) in enumerate(column) if x == 1][0]
#    return tableau[pivotRow][-1]

# # assume the last m columns of A are the slack variables; the initial basis is
# # the set of slack variables
# def initialTableau(c, A, b):
#    tableau = [row[:] + [x] for row, x in zip(A, b)]
#    tableau.append([ci for ci in c] + [0])
#    return tableau


# def primalSolution(tableau):
#    # the pivot columns denote which variables are used
#    columns = transpose(tableau)
#    indices = [j for j, col in enumerate(columns[:-1]) if isPivotCol(col)]
#    return [(colIndex, variableValueForPivotColumn(tableau, columns[colIndex]))
#             for colIndex in indices]


# def objectiveValue(tableau):
#    return -(tableau[-1][-1])


# def canImprove(tableau):
#    lastRow = tableau[-1]
#    return any(x > 0 for x in lastRow[:-1])


# # this can be slightly faster
# def moreThanOneMin(L):
#    if len(L) <= 1:
#       return False

#    x,y = heapq.nsmallest(2, L, key=lambda x: x[1])
#    return x == y


# def findPivotIndex(tableau):
#    # pick minimum positive index of the last row
#    column_choices = [(i,x) for (i,x) in enumerate(tableau[-1][:-1]) if x > 0]
#    column = min(column_choices, key=lambda a: a[1])[0]

#    # check if unbounded
#    if all(row[column] <= 0 for row in tableau):
#       raise Exception('Linear program is unbounded.')

#    # check for degeneracy: more than one minimizer of the quotient
#    quotients = [(i, r[-1] / r[column])
#       for i,r in enumerate(tableau[:-1]) if r[column] > 0]

#    if moreThanOneMin(quotients):
#       raise Exception('Linear program is degenerate.')

#    # pick row index minimizing the quotient
#    row = min(quotients, key=lambda x: x[1])[0]

#    return row, column


# def pivotAbout(tableau, pivot):
#    i,j = pivot

#    pivotDenom = tableau[i][j]
#    tableau[i] = [x / pivotDenom for x in tableau[i]]

#    for k,row in enumerate(tableau):
#       if k != i:
#          pivotRowMultiple = [y * tableau[k][j] for y in tableau[i]]
#          tableau[k] = [x - y for x,y in zip(tableau[k], pivotRowMultiple)]


# '''
#    simplex: [float], [[float]], [float] -> [float], float
#    Solve the given standard-form linear program:
#       max <c,x>
#       s.t. Ax = b
#            x >= 0
#    providing the optimal solution x* and the value of the objective function
# '''
# def simplex(c, A, b):
#    tableau = initialTableau(c, A, b)
#    print("Initial tableau:")
#    for row in tableau:
#       print(row)
#    print()

#    while canImprove(tableau):
#       pivot = findPivotIndex(tableau)
#       print("Next pivot index is=%d,%d \n" % pivot)
#       pivotAbout(tableau, pivot)
#       print("Tableau after pivot:")
#       for row in tableau:
#          print(row)
#       print()

#    return tableau, primalSolution(tableau), objectiveValue(tableau)


# if __name__ == "__main__":
#    c = [2,1]
#    A = [[1, 0], [1, 1], [3, 10]]
#    b = [3, 4, 30]

#    # add slack variables by hand
#    A[0] += [1,0,0]
#    A[1] += [0,1,0]
#    A[2] += [0,0,1]
#    c += [0,0,0]

#    t, s, v = simplex(c, A, b)
#    print(s)
#    print(v)

# import numpy as np
# from scipy.optimize import linprog

# print("Pilihlah")
# print("1. Maksimum")
# print("2. Minimum")

# A = np.array([[1, 0], [1,1], [3, 10]])
# b = np.array([3, 4, 30])
# c = np.array([-2, -1])

# t1 = 6
# t2 = 4
# t3 = 20

# # ('Optimal value:', 15100.0, '\nX:', array([ 660.,    0.,  340.]))
# res = linprog(c, A_ub=A, b_ub=b,bounds=(0, None))

# z0 = res.fun
# x0 = res.x
# print('t = 0')
# print('Z:', z0)
# print('X1:', x0)

# b1 = np.array([3+t1, 4+t2, 30+t3])

# res1 = linprog(c, A_ub=A, b_ub=b1,bounds=(0, None))
# z1 = res1.fun
# x1 = res1.x
# print('t = 1')
# print('Z:', z1)
# print('X1:', x1)


from fractions import Fraction
from warnings import warn


class Simplex(object):
    def __init__(self, num_vars, constraints, objective_function):
        """
        num_vars: Number of variables
        equations: A list of strings representing constraints
        each variable should be start with x followed by a underscore
        and a number
        eg of constraints
        ['1x_1 + 2x_2 >= 4', '2x_3 + 3x_1 <= 5', 'x_3 + 3x_2 = 6']
        Note that in x_num, num should not be more than num_vars.
        Also single spaces should be used in expressions.
        objective_function: should be a tuple with first element
        either 'min' or 'max', and second element be the equation
        eg 
        ('min', '2x_1 + 4x_3 + 5x_2')
        For solution finding algorithm uses two-phase simplex method
        """
        self.num_vars = num_vars
        self.constraints = constraints
        self.objective = objective_function[0]
        self.objective_function = objective_function[1]
        self.coeff_matrix, self.r_rows, self.num_s_vars, self.num_r_vars = self.construct_matrix_from_constraints()
        del self.constraints
        self.basic_vars = [0 for i in range(len(self.coeff_matrix))]
        self.phase1()
        r_index = self.num_r_vars + self.num_s_vars

        for i in self.basic_vars:
            if i > r_index:
                raise ValueError("Infeasible solution")

        self.delete_r_vars()

        if 'min' in self.objective.lower():
            self.solution = self.objective_minimize()

        else:
            self.solution = self.objective_maximize()
        self.optimize_val = self.coeff_matrix[0][-1]

    def construct_matrix_from_constraints(self):
        num_s_vars = 0  # number of slack and surplus variables
        num_r_vars = 0  # number of additional variables to balance equality and less than equal to
        for expression in self.constraints:
            if '>=' in expression:
                num_s_vars += 1

            elif '<=' in expression:
                num_s_vars += 1
                num_r_vars += 1

            elif '=' in expression:
                num_r_vars += 1
        total_vars = self.num_vars + num_s_vars + num_r_vars

        coeff_matrix = [[Fraction("0/1") for i in range(total_vars+1)] for j in range(len(self.constraints)+1)]
        s_index = self.num_vars
        r_index = self.num_vars + num_s_vars
        r_rows = [] # stores the non -zero index of r
        for i in range(1, len(self.constraints)+1):
            constraint = self.constraints[i-1].split(' ')

            for j in range(len(constraint)):

                if '_' in constraint[j]:
                    coeff, index = constraint[j].split('_')
                    if constraint[j-1] is '-':
                        coeff_matrix[i][int(index)-1] = Fraction("-" + coeff[:-1] + "/1")
                    else:
                        coeff_matrix[i][int(index)-1] = Fraction(coeff[:-1] + "/1")

                elif constraint[j] == '<=':
                    coeff_matrix[i][s_index] = Fraction("1/1")  # add surplus variable
                    s_index += 1

                elif constraint[j] == '>=':
                    coeff_matrix[i][s_index] = Fraction("-1/1")  # slack variable
                    coeff_matrix[i][r_index] = Fraction("1/1")   # r variable
                    s_index += 1
                    r_index += 1
                    r_rows.append(i)

                elif constraint[j] == '=':
                    coeff_matrix[i][r_index] = Fraction("1/1")  # r variable
                    r_index += 1
                    r_rows.append(i)

            coeff_matrix[i][-1] = Fraction(constraint[-1] + "/1")

        return coeff_matrix, r_rows, num_s_vars, num_r_vars

    def phase1(self):
        # Objective function here is minimize r1+ r2 + r3 + ... + rn
        r_index = self.num_vars + self.num_s_vars
        for i in range(r_index, len(self.coeff_matrix[0])-1):
            self.coeff_matrix[0][i] = Fraction("-1/1")
        coeff_0 = 0
        for i in self.r_rows:
            self.coeff_matrix[0] = add_row(self.coeff_matrix[0], self.coeff_matrix[i])
            self.basic_vars[i] = r_index
            r_index += 1
        s_index = self.num_vars
        for i in range(1, len(self.basic_vars)):
            if self.basic_vars[i] == 0:
                self.basic_vars[i] = s_index
                s_index += 1

        # Run the simplex iterations
        key_column = max_index(self.coeff_matrix[0])
        condition = self.coeff_matrix[0][key_column] > 0

        while condition is True:

            key_row = self.find_key_row(key_column = key_column)
            self.basic_vars[key_row] = key_column
            pivot = self.coeff_matrix[key_row][key_column]
            self.normalize_to_pivot(key_row, pivot)
            self.make_key_column_zero(key_column, key_row)

            key_column = max_index(self.coeff_matrix[0])
            condition = self.coeff_matrix[0][key_column] > 0

    def find_key_row(self, key_column):
        min_val = float("inf")
        min_i = 0
        for i in range(1, len(self.coeff_matrix)):
            if self.coeff_matrix[i][key_column] > 0:
                val = self.coeff_matrix[i][-1] / self.coeff_matrix[i][key_column]
                if val <  min_val:
                    min_val = val
                    min_i = i
        if min_val == float("inf"):
            raise ValueError("Unbounded solution")
        if min_val == 0:
            warn("Dengeneracy")
        return min_i

    def normalize_to_pivot(self, key_row, pivot):
        for i in range(len(self.coeff_matrix[0])):
            self.coeff_matrix[key_row][i] /= pivot

    def make_key_column_zero(self, key_column, key_row):
        num_columns = len(self.coeff_matrix[0])
        for i in range(len(self.coeff_matrix)):
            if i != key_row:
                factor = self.coeff_matrix[i][key_column]
                for j in range(num_columns):
                    self.coeff_matrix[i][j] -= self.coeff_matrix[key_row][j] * factor

    def delete_r_vars(self):
        for i in range(len(self.coeff_matrix)):
            non_r_length = self.num_vars + self.num_s_vars + 1
            length = len(self.coeff_matrix[i])
            while length != non_r_length:
                del self.coeff_matrix[i][non_r_length-1]
                length -= 1

    def update_objective_function(self):
        objective_function_coeffs = self.objective_function.split()
        for i in range(len(objective_function_coeffs)):
            if '_' in objective_function_coeffs[i]:
                coeff, index = objective_function_coeffs[i].split('_')
                if objective_function_coeffs[i-1] is '-':
                    self.coeff_matrix[0][int(index)-1] = Fraction(coeff[:-1] + "/1")
                else:
                    self.coeff_matrix[0][int(index)-1] = Fraction("-" + coeff[:-1] + "/1")

    def check_alternate_solution(self):
        for i in range(len(self.coeff_matrix[0])):
            if self.coeff_matrix[0][i] and i not in self.basic_vars[1:]:
                warn("Alternate Solution exists")
                break

    def objective_minimize(self):
        self.update_objective_function()

        for row, column in enumerate(self.basic_vars[1:]):
            if self.coeff_matrix[0][column] != 0:
                self.coeff_matrix[0] = add_row(self.coeff_matrix[0], multiply_const_row(-self.coeff_matrix[0][column], self.coeff_matrix[row+1]))

        key_column = max_index(self.coeff_matrix[0])
        condition = self.coeff_matrix[0][key_column] > 0

        while condition is True:

            key_row = self.find_key_row(key_column = key_column)
            self.basic_vars[key_row] = key_column
            pivot = self.coeff_matrix[key_row][key_column]
            self.normalize_to_pivot(key_row, pivot)
            self.make_key_column_zero(key_column, key_row)

            key_column = max_index(self.coeff_matrix[0])
            condition = self.coeff_matrix[0][key_column] > 0

        solution = {}
        for i, var in enumerate(self.basic_vars[1:]):
            if var < self.num_vars:
                solution['x_'+str(var+1)] = self.coeff_matrix[i+1][-1]

        for i in range(0, self.num_vars):
            if i not in self.basic_vars[1:]:
                solution['x_'+str(i+1)] = Fraction("0/1")
        self.check_alternate_solution()
        return solution

    def objective_maximize(self):
        self.update_objective_function()

        for row, column in enumerate(self.basic_vars[1:]):
            if self.coeff_matrix[0][column] != 0:
                self.coeff_matrix[0] = add_row(self.coeff_matrix[0], multiply_const_row(-self.coeff_matrix[0][column], self.coeff_matrix[row+1]))

        key_column = min_index(self.coeff_matrix[0])
        condition = self.coeff_matrix[0][key_column] < 0

        while condition is True:

            key_row = self.find_key_row(key_column = key_column)
            self.basic_vars[key_row] = key_column
            pivot = self.coeff_matrix[key_row][key_column]
            self.normalize_to_pivot(key_row, pivot)
            self.make_key_column_zero(key_column, key_row)

            key_column = min_index(self.coeff_matrix[0])
            condition = self.coeff_matrix[0][key_column] < 0

        solution = {}
        for i, var in enumerate(self.basic_vars[1:]):
            if var < self.num_vars:
                solution['x_'+str(var+1)] = self.coeff_matrix[i+1][-1]

        for i in range(0, self.num_vars):
            if i not in self.basic_vars[1:]:
                solution['x_'+str(i+1)] = Fraction("0/1")

        self.check_alternate_solution()

        return solution

def add_row(row1, row2):
    row_sum = [0 for i in range(len(row1))]
    for i in range(len(row1)):
        row_sum[i] = row1[i] + row2[i]
    return row_sum

def max_index(row):
    max_i = 0
    for i in range(0, len(row)-1):
        if row[i] > row[max_i]:
            max_i = i

    return max_i

def multiply_const_row(const, row):
    mul_row = []
    for i in row:
        mul_row.append(const*i)
    return mul_row

def min_index(row):
    min_i = 0
    for i in range(0, len(row)):
        if row[min_i] > row[i]:
            min_i = i

    return min_i
